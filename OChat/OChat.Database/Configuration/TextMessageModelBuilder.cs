using System;
using System.Data.Entity;
using OChat.Common;


namespace OChat.Database.Configuration
{
    internal class TextMessageModelBuilder : IDbModelConfigurator<TextMessage>
    {
        public void ConfigureDbModel(DbModelBuilder builder)
        {
            builder.Entity<TextMessage>().HasKey<Int32>(m => m.MessageId);
            builder.Entity<TextMessage>().Property(m => m.SendTimeUtc).HasColumnType("datetime2").IsRequired();
            builder.Entity<TextMessage>().Property(m => m.UrgencyLevel).IsRequired();
            builder.Entity<TextMessage>().Property(m => m.Text).IsRequired();
        }
    }
}
