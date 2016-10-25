using System;
using DDDPizzaInc.DomainModels.BaseTypes;

namespace DDDPizzaInc.DomainModels
{
    public class Bread : InventoryBase
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