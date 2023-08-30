using System;
using System.Collections.Generic;

namespace denemekardesss.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderLists = new HashSet<OrderList>();
        }

        public short Id { get; set; }
        public DateTime? Time { get; set; }
        public short? OrderSituationId { get; set; }
        public short? UserId { get; set; }

        public virtual OrderSituation? OrderSituation { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<OrderList> OrderLists { get; set; }
    }
}
