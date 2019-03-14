using _19115.Adapters;
using _19115.Domain.Ports;
using Autofac;

namespace _19115.Modules
{
    public class PortAdapterModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<NotificationFetcherAdapter>()
                .As<INotificationFetcherPort>()
                .InstancePerDependency();
            builder
                .RegisterType<NotificationMapperAdapter>()
                .As<INotificationMapperPort>()
                .InstancePerDependency();

            base.Load(builder);
        }
    }
}