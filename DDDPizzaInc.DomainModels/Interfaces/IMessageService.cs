using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDPizzaInc.DomainModels.Interfaces
{
    public interface IMessageService
    {
        void NotifyDelivery(Order order);
    }
}
