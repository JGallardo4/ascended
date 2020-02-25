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
using Microsoft.Extensions.Logging.AzureAppServices;
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
			// Use SQL Database if in Azure, otherwise, use mySQL
			if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
			{
				services.AddDbContext<AppDbContext>(options =>
					options.UseSqlServer(Configuration.GetConnectionString("AscendedDbConnection")));
			}
			else
			{
				services.AddDbContext<AppDbContext>(options =>
					options.UseMySql("Server=localhost;User Id=ascended;Password=4444;Database=AscendedGuild;",
						mySqlOptions => 
						{
							mySqlOptions
								.ServerVersion(new Version(10, 4, 11), ServerType.MariaDb);
						}));
			}
			
			// Automatically perform database migration
			services.BuildServiceProvider().GetService<AppDbContext>().Database.Migrate();

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

			services.Configure<AzureFileLoggerOptions>(Configuration.GetSection("AzureLogging"));
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
