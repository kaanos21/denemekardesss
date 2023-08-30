using System;
using System.Collections.Generic;

namespace denemekardesss.Models
{
    public partial class MenuName
    {
        public MenuName()
        {
            Foods = new HashSet<Food>();
        }

        public short MenuId { get; set; }
        public string? MenuName1 { get; set; }

        public virtual ICollection<Food> Foods { get; set; }
    }
}
