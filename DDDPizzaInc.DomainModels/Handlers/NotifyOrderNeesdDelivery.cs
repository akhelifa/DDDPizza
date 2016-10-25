using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Events;
using DDDPizzaInc.DomainModels.Events;

namespace DDDPizzaInc.DomainModels.Handlers
{
    public class NotifyOrderNeesdDelivery : IHandleEvent<OrderNeedsDelivery>
    {
        // TODO: Send a text using Twilio.com IMessageService

        public NotifyOrderNeesdDelivery()
        {
            
        }

        public void Handle(OrderNeedsDelivery args)
        {
            //Console.WriteLine("{0} placed an order", args.Order.Name);
            Trace.WriteLine("{0} placed an order", args.Order.Name);
            Debug.WriteLine("{0} placed an order", args.Order.Name);
        }
    }
}
