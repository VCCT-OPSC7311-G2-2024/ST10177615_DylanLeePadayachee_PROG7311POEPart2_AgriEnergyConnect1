// C# class generated with assistance from ChatGPT


using System.ComponentModel.DataAnnotations;

namespace AgriEnergyConnect1.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Production Date is required")]
        public DateTime ProductionDate { get; set; }

        [Required(ErrorMessage = "Farmer is required")]
        public int FarmerId { get; set; }

        public Farmer Farmer { get; set; }
    }
}