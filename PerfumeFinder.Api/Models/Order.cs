using System;
using System.Collections.Generic;

namespace PerfumeFinder.Api.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public IList<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
