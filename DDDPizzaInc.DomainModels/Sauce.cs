using System;
using DDDPizzaInc.DomainModels.BaseTypes;
using DDDPizzaInc.DomainModels.Interfaces;

namespace DDDPizzaInc.DomainModels
{
    public class Sauce : InventoryBase, IInventoryEntity
    {
        public Sauce(string name)
            : base(name)
        {
        }

        public Sauce(Guid id, string name)
            : base(id, name)
        { }

        public override bool ShouldSerializePrice()
        {
            return false;
        }


    }
}