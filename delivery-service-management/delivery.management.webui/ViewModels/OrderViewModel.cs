using System.ComponentModel.DataAnnotations;

namespace delivery.management.webui.ViewModels
{
    public class OrderViewModel
    {
        [Required]
        [Display(Name = "Name:")]
        public string PickupName { get; set; }

        [Required]
        [Display(Name = "Address:")]
        public string PickupAddress { get; set; }

        [Required]
        [Display(Name = "City:")]
        public string PickupCity { get; set; }

        [Required]
        [Display(Name = "Name:")]
        public string DeliverName { get; set; }

        [Required]
        [Display(Name = "Address:")]
        public string DeliverAddress { get; set; }

        [Required]
        [Display(Name = "City:")]
        public string DeliverCity { get; set; }

        [Required]
        [Display(Name = "Weight:")]
        public int Weight { get; set; }

        [Display(Name = "Fragile:")]
        public bool Fragile { get; set; }

        [Display(Name = "Oversized:")]
        public bool Oversized { get; set; }

    }
}
