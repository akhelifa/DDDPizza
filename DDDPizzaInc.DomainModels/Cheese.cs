using System;
using DDDPizzaInc.DomainModels.BaseTypes;

namespace DDDPizzaInc.DomainModels
{
    public class Cheese : InventoryBase
    {
        public Cheese(string name)
            : base(name)
        {
        }
        public Cheese(string name, decimal price)
            : base(name, price)
        { }

        public Cheese(Guid id, string name, decimal price)
            : base(id, name, price)
        { }

    }
}