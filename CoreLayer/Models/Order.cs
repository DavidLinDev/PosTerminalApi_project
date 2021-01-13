using System;
using System.ComponentModel.DataAnnotations;

namespace CoreLayer.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string OrderedProducts { get; set; }

        [MaxLength(200)]
        public string CustomerName { get; set; }
    }
}
