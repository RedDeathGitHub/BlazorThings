using System.ComponentModel.DataAnnotations;

namespace BlazorRevealed.Client.Data.Models
{
    public class Address
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Street must be between 3 and 50 characters long.")]
        public string Street { get; set; }

        public string Appartment { get; set; }

        public string City { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Post Number must be in XX-XXX format.")]
        public string PostNumber { get; set; }
    }
}
