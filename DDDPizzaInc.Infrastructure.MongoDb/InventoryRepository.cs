using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using DDDPizzaInc.DomainModels.BaseTypes;
using DDDPizzaInc.DomainModels.Interfaces;
using DDDPizzaInc.Interfaces;
using MongoDB.Driver;

namespace DDDPizzaInc.Infrastructure.MongoDb
{
    public class InventoryRepository<T> : IInventoryRepository<T> where T : InventoryBase, IInventoryEntity
    {

        private readonly IMongoCollection<T> _mongoCollection;

        public InventoryRepository()
        {
            IMongoClient mongoClient = new MongoClient(ConfigurationManager.AppSettings.Get("mongoConnection"));
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(ConfigurationManager.AppSettings.Get("mongoDb"));
            _mongoCollection = mongoDatabase.GetCollection<T>(typeof(T).Name);               
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await (await _mongoCollection.FindAsync(_ => true)).ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _mongoCollection.Find(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task<T> AddOrUpdate(T obj)
        {
            var existing = await GetById(obj.Id);
            if (existing == null)
            {
                await _mongoCollection.InsertOneAsync(obj);
            }
            else
            {
                await _mongoCollection.ReplaceOneAsync(x => x.Id == obj.Id, obj);
            }
            return await _mongoCollection.Find(x => x.Id == obj.Id).SingleAsync();
        }

        public virtual async Task Delete(Guid id)
        {
            await _mongoCollection.FindOneAndDeleteAsync(x => x.Id == id);
        }
    }
}
