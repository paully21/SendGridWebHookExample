using System.Data.Entity;

namespace SendGridWebHookLibrary.Models
{
    public class DataContext : DbContext
    {
        static DataContext()
        {
            Database.SetInitializer<DataContext>(null);
        }

        public DataContext()
            : base("Name=DataContext")
        {
        }

        public DbSet<SendGridEvent> SendGridEvents { get; set; }
    }
}
