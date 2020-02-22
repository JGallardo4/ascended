using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Configuration;
using AscendedGuild.Models;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Azure.KeyVault;
using Microsoft.Extensions.Configuration.AzureKeyVault;

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
				.ConfigureAppConfiguration((context, config) =>
				{
					var keyVaultEndpoint = GetKeyVaultEndpoint();

					if (!string.IsNullOrEmpty(keyVaultEndpoint))
					{
						var azureServiceTokenProvider = new AzureServiceTokenProvider();

						var keyVaultClient = new KeyVaultClient(
							new KeyVaultClient.AuthenticationCallback(
								azureServiceTokenProvider.KeyVaultTokenCallback
							)
						);

						config.AddAzureKeyVault(keyVaultEndpoint, keyVaultClient, new DefaultKeyVaultSecretManager());
					}
				})
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});

		private static string GetKeyVaultEndpoint() => "https://AscendedGuild-0-kv.vault.azure.net";				
	}
}
