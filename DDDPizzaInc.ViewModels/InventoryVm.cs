using System;
using System.ComponentModel.DataAnnotations;

namespace DDDPizzaInc.ViewModels
{
    public class InventoryVm
    {
        public Guid Id { get; set; }
        public InventoryTypeVm Type { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "Name can be no larger than 30 characters")]
        public string Name { get; set; }
    }
}