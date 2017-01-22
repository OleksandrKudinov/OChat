using System;
using System.Data.Entity;
using OChat.Common;


namespace OChat.Database.Configuration
{
    internal sealed class AccountModelBuilder : IDbModelConfigurator<Account>
    {
        public void ConfigureDbModel(DbModelBuilder builder)
        {
            builder.Entity<Account>().HasKey<String>(m => m.AccountId);
            builder.Entity<Account>().Property(m => m.Login).IsRequired();
            builder.Entity<Account>().Property(m => m.PasswordHash).IsRequired();
            builder.Entity<Account>().Property(m => m.FirstName).IsOptional();
            builder.Entity<Account>().Property(m => m.LastName).IsOptional();
        }
    }
}
