using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SampleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new SampleAppModule());
            var container = builder.Build();

            CreateHostBuilder(args)
                .UseServiceProviderFactory(new AutofacChildLifetimeScopeServiceProviderFactory(container.BeginLifetimeScope("scope")))
                .Build()
                .Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
