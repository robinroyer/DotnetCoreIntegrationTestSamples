using Autofac;

namespace SampleApp
{
    public class SampleAppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
       {
           builder
            .RegisterType<WeatherForecastService>()
            .As<WeatherForecastService>();
       }
    }
}
