using System;
using System.Data.Common;
using AscendedGuild.Data;
using AscendedGuild.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
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
			// Initialize database connection string builder and build connection string.
			var connectionStringBuilder = new DbConnectionStringBuilder();

			connectionStringBuilder.Add("Server", "localhost");
			connectionStringBuilder.Add("Database", "Ascended");
			connectionStringBuilder.Add("Uid", Configuration["Ascended--DatabaseUser"]);

			Console.WriteLine(Configuration["Ascended--DatabaseUser"]);

			connectionStringBuilder.Add("Pwd", Configuration["Ascended--DatabasePassword"]);

			Console.WriteLine(Configuration["Ascended--DatabasePassword"]);

			Console.WriteLine(connectionStringBuilder.ConnectionString);

			services.AddDbContextPool<AppDbContext>(x => x
        .UseMySql("Server=localhost;Database=AscendedTemp;Uid=ascended-temp;Pwd=q4z8EUq#%rs;",
          mySqlOptions => 
          {
            mySqlOptions
              .ServerVersion(new Version(10, 4, 11), ServerType.MariaDb);
          })
      );

			services.AddIdentity<IdentityUser, IdentityRole>()
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

			app.UseForwardedHeaders(new ForwardedHeadersOptions				
			{
				ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
			});

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
		}		
	}
}
