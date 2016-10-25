using System;
using DDDPizzaInc.DomainModels.BaseTypes;

namespace DDDPizzaInc.DomainModels
{
    public class Size : InventoryBase 
    {
        public Size(string name, decimal price)
            : base(name, price)
        { }

        public Size(Guid id, string name, decimal price)
            : base(id, name, price)
        { }
    }
}