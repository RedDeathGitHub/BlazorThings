using System.ComponentModel.DataAnnotations;

namespace BlazorRevealed.Client.Data.Models
{
    public class Person
    {
        public Person()
        {
            Address = new Address();
        }

        [Required]
        [StringLength(50, MinimumLength  = 3, ErrorMessage = "Name must be between 3 and 50 characters long.")]
        public string Name { get; set; }

        [StringLength(2000, ErrorMessage = "Description cannot be longer than 2000 characters.")]
        public string Description { get; set; }

        [Required]
        [ValidateComplexType]
        public Address Address { get; set; }

        [Range(1, 200)]
        public int Age { get; set; }
    }
}
