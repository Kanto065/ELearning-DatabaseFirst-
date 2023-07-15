using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ELearning.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Category")]
        public string Name { get; set; }
    }
}