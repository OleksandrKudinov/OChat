using Autofac;
using OChat.Common;

namespace OChat.Server
{
    public class AutofacConfigurator : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<OChat.Database.AutofacConfigurator>();
            builder.RegisterType<GlobalMessageHandler>().As<IMessageHandler<BaseMessage>>().SingleInstance();
            builder.RegisterType<TextMessageHandler>().As<IMessageHandler<TextMessage>>().SingleInstance();
        }
    }
}
