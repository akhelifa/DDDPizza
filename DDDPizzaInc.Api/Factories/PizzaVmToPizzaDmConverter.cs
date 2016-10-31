using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DDDPizzaInc.DomainModels;
using DDDPizzaInc.ViewModels;

namespace DDDPizzaInc.Api.Factories
{
    public class PizzaVmToPizzaDmConverter : ITypeConverter<PizzaVm, Pizza>
    {
        public Pizza Convert(PizzaVm source, Pizza destination, ResolutionContext context)
        {
            var toppingList = Mapper.Map<List<Topping>>(source.Topping.ToList());
            var size = Mapper.Map<Size>(source.Size);
            var bread = Mapper.Map<Bread>(source.Bread);
            var sauce = Mapper.Map<Sauce>(source.Sauce);
            var cheese = Mapper.Map<Cheese>(source.Cheese);
            return new Pizza(toppingList, size, bread, sauce, cheese);
        }
    }
}