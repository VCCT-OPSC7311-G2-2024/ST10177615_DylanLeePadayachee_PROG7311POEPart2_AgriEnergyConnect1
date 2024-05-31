using System.ComponentModel.DataAnnotations;

namespace AgriEnergyConnect1.Models
{
    public class Farmer
    {
        public int FarmerId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public int Id { get; set; }
    }
}
