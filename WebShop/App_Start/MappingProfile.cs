using ApplicationCore.DomainModel;
using AutoMapper;
using WebShop.Admin.Models;
using WebShop.DAL.POCO;
using WebShop.Models;
using WebShop.SignalR;
using System.Collections.Generic;

namespace WebShop.App_Start
{
    internal class MappingProfile : AutoMapper.Profile
    {
        protected override void Configure()
        {
            CreateMap<MessageViewModel, Message>().ForMember(x => x.MessageID, opt => opt.Ignore());

            CreateMap<Models.ProductItemViewModel, Product>()
                .ForMember(x => x.LargeImgPath, opt => opt.Ignore())
                .ForMember(x => x.Description, opt => opt.Ignore())
                .ForMember(x => x.MaterialID, opt => opt.Ignore())
                .ForMember(x => x.Material, opt => opt.Ignore())
                .ForMember(x => x.OrderItems, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Product, Models.ProductItemViewModel>()
                .AfterMap((src, dest) =>
                {
                    dest.MaterialName = src.Material.MaterialName;
                });

            CreateMap<NewProductViewModel, Product>()
               .ForMember(x => x.ProductID, opt => opt.Ignore())
               .ForMember(x => x.Diameter, opt => opt.Ignore())               
               .ForMember(x => x.Material, opt => opt.Ignore())
               .ForMember(x => x.OrderItems, opt => opt.Ignore());

            CreateMap<CartItemViewModel, Product>()
                .ForMember(x => x.Description, a => a.Ignore())
                .ForMember(x => x.Diameter, a => a.Ignore())
                .ForMember(x => x.LargeImgPath, a => a.Ignore())
                .ForMember(x => x.ThumbImgPath, a => a.Ignore())
                .ForMember(x => x.OrderItems, a => a.Ignore())
                .ForMember(x => x.MaterialID, a => a.Ignore())
                .ForMember(x => x.Material, a => a.Ignore())

                .ForMember(x => x.PricePerMeter, a => a.MapFrom(m => m.PricePerMeter))
                .ForMember(x => x.Name, a => a.MapFrom(m => m.Name))
                .ForMember(x => x.ProductID, a => a.MapFrom(m => m.ProductID))
                .ForMember(x => x.SKU, a => a.MapFrom(m => m.SKU))
                .ReverseMap();

            CreateMap<Product, CartItemViewModel>()
                .BeforeMap((s, d) => d.Amount = 1);

            CreateMap<CartItemViewModel, OrderItem>()
                .ForMember(x => x.Name, a => a.MapFrom(m => m.Name))
                .ForMember(x => x.Length, a => a.MapFrom(m => m.Length))
                .ForMember(x => x.Amount, a => a.MapFrom(m => m.Amount))
                .ForMember(x => x.Price, a => a.MapFrom(m => m.Price))
                .ForMember(x => x.PricePerItem, a => a.MapFrom(m => m.PricePerMeter))
                .ForMember(x => x.ProductID, a => a.MapFrom(m => m.ProductID))
                .ForMember(x => x.SKU, a => a.MapFrom(m => m.SKU));


            CreateMap<EditProductViewModel, Product>().ReverseMap();


            CreateMap<WebShop.Models.OrderViewModel, Order>()
                .ForMember(x => x.OrderID, opt => opt.Ignore())
                .ForMember(x => x.SummaryPrice, opt => opt.Ignore())
                .ForMember(x => x.OrderDate, opt => opt.Ignore())
                .ForMember(x => x.OrderedItems, opt => opt.Ignore());

            CreateMap<Product, ProductDetailsViewModel>();

            CreateMap<WebShop.DAL.POCO.Product, Admin.Models.ProductItemViewModel>()
                .AfterMap((src, dest) =>
                {
                    dest.MaterialName = src.Material.MaterialName;
                });

            CreateMap<WebShop.DAL.POCO.Order, WebShop.Admin.Models.OrderViewModel>();
            CreateMap<WebShop.DAL.POCO.Order, WebShop.Admin.Models.OrderViewModel>()
                .AfterMap((src, dest) =>
                {
                    dest.Customer = src.FirstName + " " + src.LastName;
                    dest.DeliveryService = src.Delivery.DeliveryService;
                });

            CreateMap<WebShop.DAL.POCO.Order, WebShop.Admin.Models.OrderItemViewModel>()
                .ForMember(x => x.Date, opt => opt.MapFrom(m => m.OrderDate))
                .ForMember(x => x.OrderID, opt => opt.MapFrom(m => m.OrderID));

            CreateMap<WebShop.DAL.POCO.Order, WebShop.Admin.Models.OrderItemViewModel>()
                .AfterMap((src, dest) =>
                {
                    dest.Customer = src.FirstName + " " + src.LastName;
                });

            CreateMap<OrderItem, WebShop.Admin.Models.OrderedProductViewModel>();
        }
    }
}
