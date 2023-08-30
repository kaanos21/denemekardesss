using System;
using System.Collections.Generic;

namespace denemekardesss.Models
{
    public partial class Category
    {
        public Category()
        {
            Foods = new HashSet<Food>();
        }

        public short CategoryId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Food> Foods { get; set; }
    }
}
