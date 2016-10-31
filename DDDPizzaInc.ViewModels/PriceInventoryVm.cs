using System.ComponentModel.DataAnnotations;

namespace DDDPizzaInc.ViewModels
{
    public class PriceInventoryVm : InventoryVm
    {
        [Required(ErrorMessage = "Cost is required")]
        public string Price { get; set; }
    }
}