using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogAsp.Models.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Display(Name = "About yourself")]
        [StringLength(2500, MinimumLength = 1, ErrorMessage = "The text must be from 1 to 25000 characters")]
        [Required(ErrorMessage = "Enter the information about yourself")]
        [DataType(DataType.MultilineText)]
        public string About { get; set; }

        [Display(Name = "Your Age")]
        [Range(0, 100, ErrorMessage = "Enter correct data")]
        [Required(ErrorMessage = "Enter your age")]
        public int Age { get; set; }

        [Display(Name = "Favourite eye color")]
        [Required(ErrorMessage = "Please, choose your favourite eye color")]
        public string Eye { get; set; }

        [Required(ErrorMessage = "Select animals")]
        public ICollection<string> Animals { get; set; }
    }
}