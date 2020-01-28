using System;
using System.Threading.Tasks;
using AscendedGuild.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace AscendedGuild
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{			
			services.AddDbContextPool<AppDbContext>(x => x
        .UseMySql(Configuration.GetConnectionString("DefaultConnection"),
          mySqlOptions => 
          {
            mySqlOptions
              .ServerVersion(new Version(10, 4, 11), ServerType.MariaDb);
          })
      );
			
			services.AddScoped<IPlayerClassRepository, PlayerClassRepository>();
			services.AddScoped<ISpecRepository, SpecRepository>();

			services.AddDefaultIdentity<IdentityUser>()
				.AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<AppDbContext>();

			services.AddHttpContextAccessor();
			services.AddControllersWithViews();
			services.AddRazorPages();

			services.AddAuthorization(options =>
			{
				options.AddPolicy("RequireAdministratorRole",
					policy => policy.RequireRole("Administrator"));
			});
		}

		// This method gets called by the runtime. 
		// Use this method to configure the HTTP request pipeline.
		public void Configure(
			IApplicationBuilder app, IWebHostEnvironment env,
			IServiceProvider serviceProvider)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			
			app.UseAuthentication();	
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseRouting();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
				
				endpoints.MapRazorPages();
			});

			CreateRoles(serviceProvider).Wait();
		}

		// This method ensures there is one and only one admin account at all times
		private async Task CreateRoles(IServiceProvider serviceProvider)
		{
			// Initialize custom roles
			var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
			string[] roles = {"Administrator"};

			foreach (var roleName in roles)
			{
				var roleExists = 
					await roleManager.RoleExistsAsync(roleName);
				
				if (!roleExists)
				{
					await roleManager.CreateAsync(new IdentityRole(roleName));
				}
			}

			// Find the user with the admin email
			var adminEmail = Configuration.GetSection("UserSettings")["UserEmail"];
      var _user = await userManager.FindByEmailAsync(adminEmail);

			if (_user == null)
			{
				// Create admin user
				var adminUser = new IdentityUser()
				{
					UserName = adminEmail,
					Email = adminEmail
				};
				string adminPassword = Configuration.GetSection("UserSettings")["UserPassword"];

				var createAdmin = await userManager.CreateAsync(adminUser, adminPassword);

				if (createAdmin.Succeeded)
				{
					// Assign admin user to admin role
					await userManager.AddToRoleAsync(adminUser, "Administrator");
				}
			}
		}
	}
}
