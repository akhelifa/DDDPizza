using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DDDPizzaInc.DomainModels.Events
{
    public class OrderNeedsDelivery : IDomainEvent
    {
        public DateTime DateOccurred { get; private set; }
        public Order Order { get; set; }
        public OrderNeedsDelivery(Order order, DateTime dateCreated)
        {
            Order = order;
            DateOccurred = dateCreated;
        }

        public OrderNeedsDelivery(Order order)
            : this(order, DateTime.UtcNow)
        {
            
        }
    }
}
