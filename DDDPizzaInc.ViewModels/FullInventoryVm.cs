using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDPizzaInc.ViewModels
{
    public class FullInventoryVm
    {

        public List<InventoryVm> Breads { get; set; }
        public List<InventoryVm> Cheeses { get; set; }
        public List<InventoryVm> Sauces { get; set; }
        public List<PriceInventoryVm> Toppings { get; set; }
        public List<PriceInventoryVm> Sizes { get; set; }
    }
}
