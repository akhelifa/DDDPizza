using Autofac;
using DDDPizzaInc.Interfaces;

namespace DDDPizzaInc.Infrastructure.MongoDb
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public IComponentContext Container;

        public RepositoryFactory(IComponentContext container)
        {
            Container = container;
        }
        public T GetRepository<T>() where T : IInventoryRepository
        {
            return Container.Resolve<T>();
        }
    }
}
