using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DDDPizzaInc.Api.Factories;
using DDDPizzaInc.DomainModels;
using DDDPizzaInc.ViewModels;

namespace DDDPizzaInc.Api.App_Start
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration MapperConfig;

        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                // Models with no price
                cfg.CreateMap<Bread, InventoryVm >()
                    .ForMember(x => x.Type, dest => dest.MapFrom(src => InventoryTypeVm.Bread))
                    .ReverseMap();

                cfg.CreateMap<Cheese, InventoryVm>()
                    .ForMember(x => x.Type, dest => dest.MapFrom(src => InventoryTypeVm.Cheese))
                    .ReverseMap();

                cfg.CreateMap<Sauce, InventoryVm>()
                    .ForMember(x => x.Type, dest => dest.MapFrom(src => InventoryTypeVm.Sauce))
                    .ReverseMap();

                // Models with Price
                cfg.CreateMap<Topping, PriceInventoryVm>()
                    .ForMember(x => x.Type, dest => dest.MapFrom(src => InventoryTypeVm.Topping))
                    .ReverseMap();

                cfg.CreateMap<Size, PriceInventoryVm>()
                    .ForMember(x => x.Type, dest => dest.MapFrom(src => InventoryTypeVm.Size))
                    .ReverseMap();

                // Pizza and Orders
                cfg.CreateMap<Pizza, PizzaVm>()
                    .ForMember(x => x.Topping, dest => dest.MapFrom(src => src.Toppings));

                cfg.CreateMap<PizzaVm, Pizza>().ConvertUsing<PizzaVmToPizzaDmConverter>();

                cfg.CreateMap<Order, OrderVm>()
                    .ForMember(x => x.Total, dest => dest.MapFrom(src => src.TotalAmount))
                    .ForMember(x => x.ServiceType, dest => dest.MapFrom(src => src.ServiceType.ToString()));

                cfg.CreateMap<OrderVm, Order>()
                    .ConvertUsing<OrderVmToOrderDmConverter>();

            });
        }
    }
}