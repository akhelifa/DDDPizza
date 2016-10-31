using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDPizzaInc.Interfaces
{
    public interface ISeedRepository
    {
        Task SeedToppings();
        Task SeedSizes();
        Task SeedSauces();
        Task SeedCheeses();
        Task SeedBreads();
    }
}
