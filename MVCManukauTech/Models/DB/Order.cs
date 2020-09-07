using System;
using System.Collections.Generic;

namespace MVCManukauTech.Models.DB
{
    public partial class Order
    {
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public decimal? GrossTotal { get; set; }
        public decimal? Discount { get; set; }
        public decimal? NetTotal { get; set; }
        public string SessionId { get; set; }
        public int? OrderStatusId { get; set; }
        public string TransactionId { get; set; }

        public virtual AspNetUsers Customer { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
