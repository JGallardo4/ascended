using System;
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

			services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppDbContext>();

			services.AddScoped<IPlayerClassRepository, PlayerClassRepository>();
			services.AddScoped<ISpecRepository, SpecRepository>();
			
			services.AddHttpContextAccessor();
			services.AddControllersWithViews();
			services.AddRazorPages();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseAuthentication();
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
