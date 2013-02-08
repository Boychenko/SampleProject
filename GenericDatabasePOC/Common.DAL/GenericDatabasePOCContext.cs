using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Common.DAL;
using Common.DAL.Mapping;

namespace Common.Domain.Models
{
    public class GenericDatabasePOCContext : DbContext
    {
        static GenericDatabasePOCContext()
        {
            Database.SetInitializer(new DbInitializer());
        }

		public GenericDatabasePOCContext()
			: base("Name=ProductCatalog")
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
