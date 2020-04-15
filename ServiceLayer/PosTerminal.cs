using System;
using System.Collections.Generic;
using System.Linq;
using CoreLayer.Models;
using CoreLayer.Services;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class PosTerminal
    {
        private readonly IProductService _productService;
        private readonly List<OrderItem> orderList = new List<OrderItem>();
        private string OrderedProducts;
        public PosTerminal(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<decimal> GenerateOrderAsync(string orderedProduct)
        {
            OrderedProducts = orderedProduct;
            string[] orders = OrderedProducts.Split(',');
            foreach (string item in orders)
            {
                var product = await _productService.GetProductByCode(item);
                if (product == null) 
                {
                    throw new InvalidOperationException($"Product : {item} does not exist for ordering");
                }

                orderList.Add(ScanProduct(product));
            }
            var totalAmount = CalculateTotal();    
            
            return totalAmount;
        }
        private  OrderItem ScanProduct(Product order)
        {
            var orderItem = new OrderItem();
            orderItem.Name = order.CodeName;
            orderItem.PaidAmount = order.UnitPrice;
            orderItem.Rebate = CalculateRebate(order);
            
            return orderItem;
        }
        private decimal CalculateRebate(Product order)
        {
            int orderedQty = orderList.FindAll(x => x.Name == order.CodeName).Count + 1;
            int discountQty = order.DiscountQtyBase;
            decimal rebate = 0;
            if (discountQty > 1 && orderedQty % discountQty == 0)
            {
                rebate = order.UnitDiscount - (order.UnitPrice * discountQty);
            }
            
            return rebate;
        }
        public decimal CalculateTotal()
        {
            var totalPaidAmount = orderList.Sum(item => item.PaidAmount);
            var totalRebate = orderList.Sum(item => item.Rebate);
            
            return totalPaidAmount + totalRebate;
        }
    }
}
