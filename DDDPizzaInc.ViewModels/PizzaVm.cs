using System.Collections.Generic;

namespace DDDPizzaInc.ViewModels
{
    public class PizzaVm
    {
        public decimal Total { get; set; }
        public InventoryVm Bread { get; set; }
        public InventoryVm Sauce { get; set; }
        public InventoryVm Cheese { get; set; }
        public PriceInventoryVm Size { get; set; }
        public List<PriceInventoryVm> Topping { get; set; }
    }
}