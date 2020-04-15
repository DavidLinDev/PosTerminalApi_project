using System;

namespace CoreLayer.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string OrderedProducts { get; set; }
    }
}
