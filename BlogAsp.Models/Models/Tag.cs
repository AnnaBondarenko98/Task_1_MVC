using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogAsp.Models.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Display(Name = "Text")]
        [Required(ErrorMessage = "Enter the text!")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Name of tariff must be from 1 to 25 characters")]
        public string Text { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
