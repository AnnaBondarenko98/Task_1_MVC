using System;
using System.ComponentModel.DataAnnotations;

namespace BlogAsp.Models.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Display(Name = "Date of adding")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Display(Name = "Your Name")]
        [Required(ErrorMessage = "Enter name")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Length must be from 3 to 100 characters")]
        public string Author { get; set; }

        [Display(Name = "Comment")]
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "Length must be from 3 to 1000 characters")]
        [Required(ErrorMessage = "Enter text")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
    }
}