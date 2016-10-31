using System.Collections.Generic;
using System.Threading.Tasks;
using DDDPizzaInc.ViewModels;

namespace DDDPizzaInc.ApplicationServices
{
    public interface IInventoryService
    {
        Task<IEnumerable<InventoryVm>> GetBreads();
        Task<IEnumerable<InventoryVm>> GetCheeses();
        Task<IEnumerable<InventoryVm>> GetSauces();
        Task<IEnumerable<PriceInventoryVm>> GetSizes();
        Task<IEnumerable<PriceInventoryVm>> GetToppings();

        Task<InventoryVm> GetBreadById(string id);
        Task<InventoryVm> GetCheeseById(string id);
        Task<InventoryVm> GetSauceById(string id);
        Task<InventoryVm> GetSizeById(string id);
        Task<InventoryVm> GetToppingById(string id);
    }
}
