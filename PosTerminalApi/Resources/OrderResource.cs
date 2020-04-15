using System;

namespace PosTerminalApi.Resources
{
    public class OrderResource
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string OrderedProducts { get; set; }
    }
}
