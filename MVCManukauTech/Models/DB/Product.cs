using System;
using System.Collections.Generic;

namespace MVCManukauTech.Models.DB
{
    public partial class Product
    {
        public Product()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public decimal? UnitPrice { get; set; }
        public string UnitType { get; set; }
        public string Description { get; set; }
        public int? QuantityInStock { get; set; }
        public bool Discontinued { get; set; }
        public int? ReorderLevel { get; set; }
        public string ImageFileName { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
