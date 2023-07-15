using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ELearning.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        [Required]
        public string Learning { get; set; }
        public Nullable<int> CategoryId { get; set; }

        public CategoryModel Category { get; set; }
    }
}