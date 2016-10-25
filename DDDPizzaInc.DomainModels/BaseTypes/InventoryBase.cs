using System;

namespace DDDPizzaInc.DomainModels.BaseTypes
{
    public abstract class InventoryBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual decimal Price { get; private set; }


        protected InventoryBase()
        { }

        protected InventoryBase(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }

        protected InventoryBase(string name, decimal price)
            : this(name)
        {
            Price = price;
        }

        protected InventoryBase(Guid id, string name)
            : this(name)
        {
            Id = id;

        }

        protected InventoryBase(Guid id, string name, decimal price)
            : this(name, price)
        {
            Id = id;
        }


        #region "Mongo Overwrite"

        public virtual bool ShouldSerializePrice()
        {
            return true;
        }

        #endregion
    }
}