
namespace PosTerminalApi.Resources
{
    public class ProductResource
    {
        public int Id { get; set; }
        public string CodeName { get; set; }
        public decimal UnitPrice { get; set; }
        public int DiscountQtyBase { get; set; }
        public decimal UnitDiscount { get; set; }
    }
}
