using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SampleApp.Tests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<SampleApp.Startup>
    {
        public CustomWebApplicationFactory() : base()
        {
        }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new SampleAppModule());
            var container = containerBuilder.Build();

            builder.UseServiceProviderFactory(new AutofacChildLifetimeScopeServiceProviderFactory(container.BeginLifetimeScope("scope")));

            var host = builder.Build();
            host.Start();
            return host;
        }
    }
}