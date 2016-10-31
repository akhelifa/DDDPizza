using System.Reflection;
using Autofac;
using Autofac.Events;
using Autofac.Features.Variance;
using Autofac.Integration.WebApi;
using DDDPizzaInc.ApplicationServices;
using DDDPizzaInc.DomainModels;
using DDDPizzaInc.DomainModels.Events;
using DDDPizzaInc.DomainModels.Handlers;
using DDDPizzaInc.DomainModels.Interfaces;
using DDDPizzaInc.Infrastructure;
using DDDPizzaInc.Infrastructure.MongoDb;
using DDDPizzaInc.Interfaces;

namespace DDDPizzaInc.Api.App_Start
{
    public static class AutofacBootStrapper
    {
        public static AutofacWebApiDependencyResolver AutofacWebApiDependencyResolver()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterSource(new ContravariantRegistrationSource());
            builder.RegisterEventing();

            builder.RegisterType<NotifyOrderNeedsDelivery>().As<IHandleEvent<OrderNeedsDelivery>>();

            builder.RegisterType<InventoryService>().As<IInventoryService>();
            builder.RegisterType<MessageService>().As<IMessageService>();
            builder.RegisterType<OrderService>().As<IOrderService>();

            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<RepositoryFactory>().As<IRepositoryFactory>();

            builder.RegisterType<InventoryRepository<Bread>>().As<IInventoryRepository<Bread>>();
            builder.RegisterType<InventoryRepository<Cheese>>().As<IInventoryRepository<Cheese>>();
            builder.RegisterType<InventoryRepository<Sauce>>().As<IInventoryRepository<Sauce>>();
            builder.RegisterType<InventoryRepository<Topping>>().As<IInventoryRepository<Topping>>();
            builder.RegisterType<InventoryRepository<Size>>().As<IInventoryRepository<Size>>();



            var container = builder.Build();
            return new AutofacWebApiDependencyResolver(container);            
        }
    }
}