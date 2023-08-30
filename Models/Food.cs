using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace denemekardesss.Models
{
    public partial class Food
    {
        public Food()
        {
            OrderLists = new HashSet<OrderList>();
        }
        [Key]

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public short Id { get; set; }
        public short? CategoryId { get; set; }
        public int? Price { get; set; }
        public short? MenuId { get; set; }
        public string? Explanition { get; set; }

        public virtual Category? Category { get; set; }
        public virtual MenuName? Menu { get; set; }
        public virtual ICollection<OrderList> OrderLists { get; set; }
    }
}
