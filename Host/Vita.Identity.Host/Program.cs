using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;

namespace Vita.Identity.Host
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "IdentityServer";

            BuildWebHostBuilder(args).Build().Run();
        }

        public static IHostBuilder BuildWebHostBuilder(string[] args)
        {
            return Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                .UseSerilog((ctx, config) =>
                {
                    config.MinimumLevel.Debug()
                        .MinimumLevel.Debug()
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                        .MinimumLevel.Override("System", LogEventLevel.Warning)
                        .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
                        .Enrich.FromLogContext();

                    if (ctx.HostingEnvironment.IsDevelopment())
                        config.WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}");
                })
                //.ConfigureAppConfiguration((ctx, builder) =>
                // {
                //     var config = builder.Build();
                //     var tokenProvider = new AzureServiceTokenProvider();
                //     var kvClient = new KeyVaultClient((authority, resource, scope) => tokenProvider.KeyVaultTokenCallback(authority, resource, scope));

                //     builder.AddAzureKeyVault(config["KeyVault:BaseUrl"], kvClient, new DefaultKeyVaultSecretManager());
                // })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
