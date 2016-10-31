using System;
using DDDPizzaInc.DomainModels.BaseTypes;
using DDDPizzaInc.DomainModels.Interfaces;

namespace DDDPizzaInc.DomainModels
{
    public class Size : InventoryBase, IInventoryEntity 
    {
        public Size(string name, decimal price)
            : base(name, price)
        { }

        public Size(Guid id, string name, decimal price)
            : base(id, name, price)
        { }
    }
}