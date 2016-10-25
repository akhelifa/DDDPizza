using System;
using DDDPizzaInc.DomainModels.BaseTypes;

namespace DDDPizzaInc.DomainModels
{
    public class Topping : InventoryBase
    {
        public Topping(string name, decimal price)
            : base(name, price)
        { }

        public Topping(Guid id, string name, decimal price)
            : base(id, name, price)
        { }
    }
}