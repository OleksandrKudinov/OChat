using System.Data.Entity;
using OChat.Database.Configuration;
using OChat.Common;

namespace OChat.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("localSQLInstance")
        {
            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            new TextMessageModelBuilder().ConfigureDbModel(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TextMessage> TextMessages { get; set; }
    }
}