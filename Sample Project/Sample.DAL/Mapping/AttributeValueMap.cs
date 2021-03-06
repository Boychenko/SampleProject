﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Domain.Models;

namespace Sample.DAL.Mapping
{
	class AttributeValueMap : EntityTypeConfiguration<AttributeValue>
	{
		public AttributeValueMap()
		{
			// Primary Key
			this.HasKey(t => t.Id);

			// Properties
			this.Property(t => t.Value)
				.IsRequired()
				.HasMaxLength(250);
		}
	}
}
