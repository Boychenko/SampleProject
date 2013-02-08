using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.DAL.Mapping
{
	public class AttributeMap : EntityTypeConfiguration<Sample.Domain.Models.Attribute>
	{
		public AttributeMap()
		{
			// Primary Key
			this.HasKey(t => t.Id);

			// Properties
			this.Property(t => t.Name)
				.IsRequired()
				.HasMaxLength(250);
			this.HasMany(a => a.AttributeValues).WithRequired(av => av.Attribute).Map(m => m.MapKey("AttributeId"));
		}
	}
}
