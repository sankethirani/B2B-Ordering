using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCManukauTech.ViewModels
{
    public class CheckoutViewModel
    {
        [Key]
        public int CheckoutId { get; set; }
        public string ShipName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public decimal Discount { get; set; }
        public decimal GrossTotal { get; set; }
        public decimal? GrandTotal { get; set; }
        public string ShipAddress { get; set; }
    }
}
