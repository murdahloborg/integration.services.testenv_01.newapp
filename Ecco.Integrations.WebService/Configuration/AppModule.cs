using Autofac;
using Ecco.Integrations.WebService.Services;

namespace Ecco.Integrations.WebService.Configuration
{
    public class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SendProductSampleService>().As<ISendProductSampleService>().SingleInstance();
        }
    }
}
