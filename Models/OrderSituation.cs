using System;
using System.Collections.Generic;

namespace denemekardesss.Models
{
    public partial class OrderSituation
    {
        public OrderSituation()
        {
            Orders = new HashSet<Order>();
        }

        public short Id { get; set; }
        public string? Situation { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
