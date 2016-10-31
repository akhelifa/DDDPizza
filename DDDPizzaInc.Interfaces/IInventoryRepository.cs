using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDPizzaInc.DomainModels.Interfaces;

namespace DDDPizzaInc.Interfaces
{
    public interface IInventoryRepository
    {
    }

    public interface IInventoryRepository<T> : IInventoryRepository where T : IInventoryEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> AddOrUpdate(T obj);
        Task Delete(Guid id);
    }

}
