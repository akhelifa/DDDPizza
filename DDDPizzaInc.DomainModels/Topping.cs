using System;
using DDDPizzaInc.DomainModels.BaseTypes;
using DDDPizzaInc.DomainModels.Interfaces;

namespace DDDPizzaInc.DomainModels
{
    public class Topping : InventoryBase, IInventoryEntity
    {
        public Topping(string name, decimal price)
            : base(name, price)
        { }

        public Topping(Guid id, string name, decimal price)
            : base(id, name, price)
        { }
    }
}