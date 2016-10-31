using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDPizzaInc.DomainModels;

namespace DDDPizzaInc.Interfaces
{
    public interface IOrderRepository : IInventoryRepository
    {
        Task<IEnumerable<Order>> GetAllByStatus(ServiceType type);
        Task<IEnumerable<Order>> GetAll();
        Task<IEnumerable<Order>> GetAllCurrentOrders();
        Task<IEnumerable<Order>> GetAllPastOrders();
        Task<long> GetAllPending();
        Task<Order> GetById(Guid id);
        Task<Order> Add(Order order);
    }
}
