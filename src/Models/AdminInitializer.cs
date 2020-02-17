using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AscendedGuild.Models
{
	public static class AdminInitializer
	{
		// This method ensures there is one and only one admin account at all times
		public static async Task CreateRoles(
			IServiceProvider serviceProvider, IConfiguration configuration)
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
			var adminEmail = "ascended.admin@gmail.com";
      var _user = await userManager.FindByEmailAsync(adminEmail);

			if (_user == null)
			{
				// Create admin user
				var adminUser = new IdentityUser()
				{
					UserName = adminEmail,
					Email = adminEmail
				};
				string adminPassword = "rFPin @n4val";

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