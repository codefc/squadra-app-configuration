using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using System;

namespace SquadraExperience.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) => {
                IConfigurationRoot settings = config.Build();

                config.AddAzureAppConfiguration(option => {
                    option.Connect("SUA_CONNECTION_STRING")
                        .ConfigureRefresh(refresh => {
                            refresh.Register("DevOpsBH:Dog:DogName", context.HostingEnvironment.EnvironmentName)
                            .SetCacheExpiration(TimeSpan.FromSeconds(5))
                            ;
                        }).UseFeatureFlags();
                });
            })
                .UseStartup<Startup>();
    }
}
