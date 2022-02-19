using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotNetLabExam.Models
{
    public class Products
    {
        [Key]
        public int Productid { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Please enter Product Name")]
        [Display(Name ="ProductName")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please enter Rate")]
        [Display(Name = "Rate")]
        public decimal Rate { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter Description")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter Category Name")]
        [Display(Name = "CategoryName")]
        public string CategoryName { get; set; }
    }
}