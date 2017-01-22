using Autofac;
using OChat.Common;

namespace OChat.Database
{
    public class AutofacConfigurator : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TextMessageRepository>().As<IRepository<TextMessage>>();
            builder.RegisterType<AccountRepository>().As<IRepository<Account>>();
        }
    }
}
