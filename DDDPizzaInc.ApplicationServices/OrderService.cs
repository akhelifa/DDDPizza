using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Autofac.Events;
using DDDPizzaInc.DomainModels;
using DDDPizzaInc.Interfaces;
using DDDPizzaInc.SharedKernel;
using DDDPizzaInc.ViewModels;

namespace DDDPizzaInc.ApplicationServices
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IEventPublisher _eventPublisher;

        public OrderService(IOrderRepository orderRepository, IEventPublisher eventPublisher)
        {
            _orderRepository = orderRepository;
            _eventPublisher = eventPublisher;
        }
        public async Task<OrderVm> GetOrderByIdAsync(string id)
        {
            var result = await _orderRepository.GetById(Guid.Parse(id));
            var vm = AutoMapper.Mapper.Map<Order, OrderVm>(result);
            return vm;
        }

        public async Task<IEnumerable<OrderVm>> GetAllOrdersAsync()
        {
            var result = await _orderRepository.GetAll();
            var vm = AutoMapper.Mapper.Map<List<Order>, List<OrderVm>>(result.OrderByDescending(x => x.DateTimeStamp).ToList());
            return vm;
        }

        public async Task<IEnumerable<OrderVm>> GetAllCurrentOrdersAsync()
        {
            var result = await _orderRepository.GetAllCurrentOrders();
            var vm = AutoMapper.Mapper.Map<List<Order>, List<OrderVm>>(result.OrderByDescending(x => x.DateTimeStamp).ToList());
            return vm;
        }

        public async Task<IEnumerable<OrderVm>> GetAllPastOrdersAsync()
        {
            var result = await _orderRepository.GetAllPastOrders();
            var vm = AutoMapper.Mapper.Map<List<Order>, List<OrderVm>>(result.OrderByDescending(x => x.DateTimeStamp).ToList());
            return vm;
        }

        public async Task<IEnumerable<OrderVm>> GetAllOrdersByServiceTypeAsync(string type)
        {
            var servType = Enumeration.FromDisplayName<ServiceType>(type.Replace(" ", ""));
            var result = await _orderRepository.GetAllByStatus(servType);
            var vm = AutoMapper.Mapper.Map<List<Order>, List<OrderVm>>(result.OrderByDescending(x => x.DateTimeStamp).ToList());
            return vm;
        }

        public async Task<OrderVm> PlaceOrderAsync(OrderVm order)
        {
            var vm = AutoMapper.Mapper.Map<OrderVm, Order>(order);
            long existingOrder = 0;
            var countTask = Task.Factory.StartNew(() => existingOrder = CountPendingOrders().Result);
            countTask.Wait();
            vm.SetEstimatedReadyTime(existingOrder);
            var dm = await _orderRepository.Add(vm);
            dm.ProcessOrder(dm, _eventPublisher);
            return AutoMapper.Mapper.Map<Order, OrderVm>(dm);
        }


        public IDictionary<string, string> GetServiceOptions()
        {
            var result =
                Enumeration.GetAll<ServiceType>()
                    .ToDictionary(key => key.DisplayName, val => Regex.Replace(val.DisplayName, @"([a-z])([A-Z])", "$1 $2"));
            return result;
        }

        /// <summary>
        /// Get the current amout of pending orders the given date and time
        /// </summary>
        public async Task<long> CountPendingOrders()
        {

            return await _orderRepository.GetAllPending();
        }
    }
}