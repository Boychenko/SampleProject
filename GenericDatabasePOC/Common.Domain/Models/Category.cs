using System;
using System.Collections.Generic;

namespace Common.Domain.Models
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
		public ICollection<Product> Products { get; set; }
		public Category Parent { get; set; }
		public ICollection<Category> ChildCategories { get; set; }
    }
}
