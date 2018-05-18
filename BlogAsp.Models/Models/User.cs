using System.ComponentModel.DataAnnotations;

namespace BlogAsp.Models.Models
{
    public class User
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Enter the Name !")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "The length must be from 3 to 25 symbols")]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Enter your surname !")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The length must be from 3 to 100 symbols")]
        public string LastName { get; set; }
    }
}
