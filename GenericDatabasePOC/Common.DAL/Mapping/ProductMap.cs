using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Common.Domain.Models;

namespace Common.DAL.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
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
            this.ToTable("Products");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.CreatedTime).HasColumnName("CreatedTime");

			// Attendance has 1 Session, Sessions have many Attendance records
			
			HasMany(p => p.Categories)
				.WithMany(c=>c.Products)
				.Map(m =>
					{
						m.ToTable("ProductCategories");
						m.MapLeftKey("ProductId");
						m.MapRightKey("CategoryId");
					});
	        HasMany(p => p.AttributeValues).WithRequired(a => a.Product).Map(m => m.MapKey("ProductId"));

	        // Attendance has 1 Person, Persons have many Attendance records
	        //HasRequired(a => a.Person)
	        //	.WithMany(p => p.AttendanceList)
	        //	.HasForeignKey(a => a.PersonId)
	        //	.WillCascadeOnDelete(false);
        }
    }
}
