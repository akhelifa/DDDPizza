using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DDDPizzaInc.DomainModels;

namespace DDDPizzaInc.Mocks
{
    public class PizzaMocks
    {
        public static ICollection<Cheese> GetCheese()
        {       
            return new Collection<Cheese>
            {
                new Cheese("Mozzarella"),
                new Cheese("Provolone"),
                new Cheese("Italian Hard Cheeses")
            };
        }


        public static ICollection<Sauce> GetSauces()
        {
            return new Collection<Sauce>
            {
                new Sauce("Tomato"),
                new Sauce("Pesto"),
                new Sauce("Muhammara"),
                new Sauce("Barbecue"),
                new Sauce("Tapenade")
            };
        }

        public static ICollection<Bread> BreadMocks()
        {
            return new Collection<Bread>
            {
                new Bread("Hand Tossed"),
                new Bread("Deep Dish"),
                new Bread("Thin"),
                new Bread("Stuffed")
            };
        }

        public static ICollection<Size> SizeMocks()
        {
            return new Collection<Size>
            {
                new Size("Small", 10.99m),
                new Size("Medium", 12.99m),
                new Size("Large", 14.99m),
                new Size("Extra Large", 16.99m),
            };
        }


        public static ICollection<Topping> ToppingMocks()
        {
            return new Collection<Topping>
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
        }

    }
}
