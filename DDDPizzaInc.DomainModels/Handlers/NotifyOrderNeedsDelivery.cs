using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Events;
using DDDPizzaInc.DomainModels.Events;
using DDDPizzaInc.DomainModels.Interfaces;

namespace DDDPizzaInc.DomainModels.Handlers
{
    public class NotifyOrderNeedsDelivery : IHandleEvent<OrderNeedsDelivery>
    {
        private readonly IMessageService _messageService;

        public NotifyOrderNeedsDelivery(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public void Handle(OrderNeedsDelivery args)
        {
            _messageService.NotifyDelivery(args.Order);
        }
    }
}
