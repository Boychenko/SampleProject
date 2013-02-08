using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Sample.DAL;
using Sample.DAL.Mapping;

namespace Sample.Domain.Models
{
    public class SampleContext : DbContext
    {
        static SampleContext()
        {
            Database.SetInitializer(new DbInitializer());
        }

		public SampleContext()
			: base("Name=SampleProject")
		{
		}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ProductMap());
			modelBuilder.Configurations.Add(new AttributeValueMap());
			modelBuilder.Configurations.Add(new AttributeMap());
        }
    }
}
