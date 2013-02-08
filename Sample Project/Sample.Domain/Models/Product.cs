using System;
using System.Collections.Generic;

namespace Sample.Domain.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
		public ICollection<Category> Categories { get; set; }
		public ICollection<AttributeValue> AttributeValues { get; set; }
    }
}
