using System;
using DDDPizzaInc.DomainModels.BaseTypes;

namespace DDDPizzaInc.DomainModels
{
    public class Sauce : InventoryBase
    {
        public Sauce(string name)
            : base(name)
        {
        }

        public Sauce(Guid id, decimal price)
            : base(id, price)
        { }

        public Sauce(Guid id, string name, decimal price)
            : base(id, name, price)
        { }


    }
}