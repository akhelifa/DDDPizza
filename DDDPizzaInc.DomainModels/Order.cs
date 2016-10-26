using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using Autofac.Events;
using DDDPizzaInc.DomainModels.Events;
using DDDPizzaInc.SharedKernel;

namespace DDDPizzaInc.DomainModels
{
    public class Order : Entity
    {
        public Order(ServiceType service, List<Pizza> pizzas, string name)
        {
            Guard.ForNullOrEmpty(name, "Customer Name must be provided");
            Name = name;
            ServiceType = service;
            Pizzas = pizzas;
            CalculateTotal();
            DateTimeStamp = DateTime.UtcNow;
        }
        public string Name { get; set; }
        public ServiceType ServiceType { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public DateTime DateTimeStamp { get; private set; }
        public decimal SubTotal { get; private set; }
        public decimal ServiceCharge { get; private set; }
        public decimal TotalAmount { get; private set; }
        public DateTime EstimatedReadyTime { get; private set; } // 20 mins + active = 20, 24

        private void CalculateTotal()
        {
            foreach (var order in Pizzas)
            {
                SubTotal += order.Total;
            }

            ServiceCharge = ServiceType.CalculateTotal(this.ServiceType);

            TotalAmount = SubTotal + ServiceCharge;

        }

        public void SetEstimatedReadyTime(long existingOrders)
        {
            EstimatedReadyTime = DateTime.UtcNow.AddMinutes(20).AddMinutes(existingOrders * 2);
        }

        public void ProcessOrder(Order order, IEventPublisher eventPublisher)
        {

            if (Equals(order.ServiceType, ServiceType.Delivery))
            {
                eventPublisher.Publish(new OrderNeedsDelivery(this));
            }
        }
    }
} 
