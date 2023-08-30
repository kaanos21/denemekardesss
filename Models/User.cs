using System;
using System.Collections.Generic;

namespace denemekardesss.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public short Id { get; set; }
        public string? UserName { get; set; }
        public string? UserPassword { get; set; }
        public int? UserMoney { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
