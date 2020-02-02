using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Configuration;
using AscendedGuild.Models;

namespace AscendedGuild
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();   

			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				var serviceProvider = services.GetRequiredService<IServiceProvider>();
				var configuration = services.GetRequiredService<IConfiguration>();

				AdminInitializer.CreateRoles(serviceProvider, configuration).Wait();					
			}
      
			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
