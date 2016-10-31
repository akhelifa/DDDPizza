using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDPizzaInc.Interfaces
{
    public interface IRepositoryFactory
    {
        T GetRepository<T>() where T : IInventoryRepository;
    }
}
