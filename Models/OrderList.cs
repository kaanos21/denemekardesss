using System;
using System.Collections.Generic;

namespace denemekardesss.Models
{
    public partial class OrderList
    {
        public short Id { get; set; }
        public short? OrderId { get; set; }
        public short? FoodId { get; set; }

        public virtual Food? Food { get; set; }
        public virtual Order? Order { get; set; }
    }
}
