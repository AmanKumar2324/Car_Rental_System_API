using System.ComponentModel.DataAnnotations;

namespace Car_Rental_System_API.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Make { get; set; }

        [Required]
        [MaxLength (100)]
        public string Model { get; set; }

        [Required]
        [Range(1900, 2025, ErrorMessage = "Year must be between 1900 and 2025.")]
        public int Year { get; set; }

        [Required]
        [Range(0.0, double.MaxValue, ErrorMessage = "Price per day must be a positive value.")]
        public decimal PricePerDay { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
    }
}
