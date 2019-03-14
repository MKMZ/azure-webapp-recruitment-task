using _19115.Domain.UseCases;
using Autofac;

namespace _19115.Modules
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<GetNotificationsUseCase>()
                .As<IGetNotificationsUseCase>()
                .InstancePerDependency();

            base.Load(builder);
        }
    }
}