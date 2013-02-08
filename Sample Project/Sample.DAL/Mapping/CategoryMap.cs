using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Sample.Domain.Models;

namespace Sample.DAL.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Categories");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");

	        HasMany(c => c.ChildCategories).WithOptional(c => c.Parent).Map(m =>
		        {
			        m.MapKey("ParentId");
		        });

        }
    }
}
