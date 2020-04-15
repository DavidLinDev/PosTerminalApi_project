using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLayer.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string CodeName { get; set; }
        public decimal UnitPrice { get; set; }
        public int DiscountQtyBase { get; set; }
        public decimal UnitDiscount { get; set; }
    }
}
