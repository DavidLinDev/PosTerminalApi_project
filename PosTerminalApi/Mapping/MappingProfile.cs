using AutoMapper;
using PosTerminalApi.Resources;
using CoreLayer.Models;

namespace MyMusic.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Product, ProductResource>();
            CreateMap<Order, OrderResource>();

            // Resource to Domain
            CreateMap<ProductResource, Product>();
            CreateMap<SaveProductResource, Product>();
            CreateMap<OrderResource, Order>();
            CreateMap<SaveOrderResource, Order>();
        }
    }
}
