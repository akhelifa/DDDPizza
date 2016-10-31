using System;
using DDDPizzaInc.DomainModels.BaseTypes;
using DDDPizzaInc.DomainModels.Interfaces;

namespace DDDPizzaInc.DomainModels
{
    public class Bread : InventoryBase, IInventoryEntity
    {
        public Bread(string name)
            : base(name)
        {

        }
         public Bread(Guid id, string name)
            : base(id, name)
        { }

        public override bool ShouldSerializePrice()
        {
            return false;
        }
    }
}