using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DDDPizzaInc.DomainModels;
using DDDPizzaInc.SharedKernel;
using DDDPizzaInc.ViewModels;

namespace DDDPizzaInc.Api.Factories
{
    public class OrderVmToOrderDmConverter : ITypeConverter<OrderVm, Order>
    {
        public Order Convert(OrderVm source, Order destination, ResolutionContext context)
        {
            var servType = Enumeration.FromDisplayName<ServiceType>(source.ServiceType.Replace(" ", ""));
            //var pizzas = src.Pizzas.Select(x => Mapper.Map<PizzaVm, Pizza>(x)).ToList();
            var pizzas = source.Pizzas.Select(Mapper.Map<PizzaVm, Pizza>).ToList();
            var result = new Order(servType, pizzas, source.Name);
            return result;
        }
    }
}