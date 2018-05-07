using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BlogAsp.Models.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Enter the name of tariff!")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Name of tariff must be from 3 to 25 characters")]
        public string Name { get; set; }

        [Display(Name = "Date of connection")]
        [DataType(DataType.DateTime)]
        [Remote("CheckDate", "Article", HttpMethod = "POST", ErrorMessage = "Date is not valid.")]
        public DateTime Date { get; set; }

        [Display(Name = "Article text")]
        [StringLength(2500, MinimumLength = 1, ErrorMessage = "The text of article must be from 1 to 25000 characters")]
        [DataType(DataType.Text)]
        public string Text { get; set; }
    }
}