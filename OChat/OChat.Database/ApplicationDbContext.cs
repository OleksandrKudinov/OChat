using System.Data.Entity;

namespace OChat.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("localSQLInstance")
        {
            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }
    }
}