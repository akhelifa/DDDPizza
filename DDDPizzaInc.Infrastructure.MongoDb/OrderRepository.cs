using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDPizzaInc.DomainModels;
using DDDPizzaInc.Interfaces;
using MongoDB.Driver;

namespace DDDPizzaInc.Infrastructure.MongoDb
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoCollection<Order> _mongoOrdersCollection; 

        public OrderRepository()
        {
            IMongoClient mongoClient = new MongoClient(ConfigurationManager.AppSettings.Get("mongoConnection"));
            var mongoDatabase = mongoClient.GetDatabase(ConfigurationManager.AppSettings.Get("mongoDb"));
            _mongoOrdersCollection = mongoDatabase.GetCollection<Order>("Orders");                
        }

        public async Task<IEnumerable<Order>> GetAllByStatus(ServiceType type)
        {
            return await (await _mongoOrdersCollection.FindAsync(x => Equals(x.ServiceType, type))).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await (await _mongoOrdersCollection.FindAsync(_ => true)).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllCurrentOrders()
        {
            return await (await _mongoOrdersCollection.FindAsync(x => x.DateTimeStamp < DateTime.UtcNow && x.EstimatedReadyTime > DateTime.UtcNow)).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllPastOrders()
        {
            return await (await _mongoOrdersCollection.FindAsync(x => x.EstimatedReadyTime < DateTime.UtcNow)).ToListAsync();
        }

        public async Task<long> GetAllPending()
        {
            return await _mongoOrdersCollection.CountAsync(x => x.EstimatedReadyTime > DateTime.UtcNow);
        }

        public async Task<Order> GetById(Guid id)
        {
            return await _mongoOrdersCollection.Find(x => x.Id == id).SingleAsync();
        }

        public async Task<Order> Add(Order order)
        {
            await _mongoOrdersCollection.InsertOneAsync(order);
            return order;
        }
    }
}
