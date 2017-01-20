using System.Data.Entity;

namespace OChat.Database.Configuration
{
    internal interface IDbModelConfigurator<T>
    {
        void ConfigureDbModel(DbModelBuilder builder);
    }
}
