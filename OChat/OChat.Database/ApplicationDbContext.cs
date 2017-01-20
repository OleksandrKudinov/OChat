using System.Data.Entity;
using OChat.Common;

namespace OChat.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("localSQLInstance")
        {
            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }

        public DbSet<TextMessage> TextMessages { get; set; }
    }
}