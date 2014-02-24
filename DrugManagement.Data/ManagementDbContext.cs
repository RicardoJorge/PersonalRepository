using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DrugManagement.Model;

namespace DrugManagement.Data
{
    public class ManagementDbContext : DbContext
    {
        public ManagementDbContext() : base(nameOrConnectionString: "DrugManagement.Data.ManagementDbContext")
        {
        }

        public DbSet<Drug> Drugs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
