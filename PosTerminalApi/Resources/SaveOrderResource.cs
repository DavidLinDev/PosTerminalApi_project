using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosTerminalApi.Resources
{
    public class SaveOrderResource
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string OrderedProducts { get; set; }
    }
}
