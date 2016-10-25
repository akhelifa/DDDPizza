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
        public Cheese(Guid id, string name)
            : base(id, name)
        { }

        public override bool ShouldSerializePrice()
        {
            return false;
        }

    }
}