using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDPizzaInc.DomainModels;
using DDDPizzaInc.Interfaces;
using MongoDB.Driver;

namespace DDDPizzaInc.Infrastructure.MongoDb
{
    public class SeedRepository : ISeedRepository
    {
        private readonly IMongoDatabase _mongoDatabase;

        public SeedRepository()
        {
            IMongoClient mongoClient = new MongoClient(ConfigurationManager.AppSettings.Get("mongoConnection"));
            _mongoDatabase = mongoClient.GetDatabase(ConfigurationManager.AppSettings.Get("mongoDb"));
        }
        public async Task SeedToppings()
        {
            var mongoToppingsCollection = _mongoDatabase.GetCollection<Topping>("Topping");
            if (await mongoToppingsCollection.CountAsync(_ => true) == 0)
            {
                var seedToppings = new Collection<Topping>
                {
                    new Topping("Pepperoni", 0.99m),
                    new Topping("Mushrooms", 0.99m),
                    new Topping("Bacon", 1.99m),
                    new Topping("Extra cheese", 1.99m),
                    new Topping("Black olives", 1.99m),
                    new Topping("Green peppers", 1.99m),
                    new Topping("Sausage", 0.99m),
                    new Topping("Pineapple", 0.99m),
                    new Topping("Spinach", 0.99m)
                };
                foreach (var topping in seedToppings)
                {
                    await mongoToppingsCollection.InsertOneAsync(topping);
                }
            }
        }

        public async Task SeedSizes()
        {
            var mongoSizesCollection = _mongoDatabase.GetCollection<Size>("Size");
            if (await mongoSizesCollection.CountAsync(_ => true) == 0)
            {
                var seed = new Collection<Size>
                {
                    new Size("Small", 10.99m),
                    new Size("Medium", 12.99m),
                    new Size("Large", 14.99m),
                    new Size("Extra Large", 16.99m),
                };
                foreach (var item in seed)
                {
                    await mongoSizesCollection.InsertOneAsync(item);
                }
            }
        }

        public async Task SeedSauces()
        {
            var mongoSauceCollection = _mongoDatabase.GetCollection<Sauce>("Sauce");
            if (await mongoSauceCollection.CountAsync(_ => true) == 0)
            {
                var seed = new Collection<Sauce>
                {
                    new Sauce("Tomato"),
                    new Sauce("Pesto"),
                    new Sauce("Muhammara"),
                    new Sauce("Barbecue"),
                    new Sauce("Tapenade")
                };
                foreach (var item in seed)
                {
                    await mongoSauceCollection.InsertOneAsync(item);
                }
            }           
        }

        public async Task SeedCheeses()
        {
            var mongoCheeseCollection = _mongoDatabase.GetCollection<Cheese>("Cheese");
            if (await mongoCheeseCollection.CountAsync(_ => true) == 0)
            {
                var seed = new Collection<Cheese>
                {
                    new Cheese("Mozzarella"),
                    new Cheese("Provolone"),
                    new Cheese("Italian Hard Cheeses")
                };
                foreach (var item in seed)
                {
                    await mongoCheeseCollection.InsertOneAsync(item);
                }
            }          
        }

        public async Task SeedBreads()
        {
            var mongoBreadCollection = _mongoDatabase.GetCollection<Bread>("Bread");
            if (await mongoBreadCollection.CountAsync(_ => true) == 0)
            {
                var seed = new Collection<Bread>
                {
                    new Bread("Hand Tossed"),
                    new Bread("Deep Dish"),
                    new Bread("Thin"),
                    new Bread("Stuffed")
                };
                foreach (var item in seed)
                {
                    await mongoBreadCollection.InsertOneAsync(item);
                }
            }
        }
    }
}
