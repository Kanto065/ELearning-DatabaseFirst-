using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ELearning.Models
{
    public class InstructorModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required]
        [StringLength(14, ErrorMessage = "Please do not enter values over 50 characters")]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public Nullable<int> AddressId { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-zA-Z])(?=.*[@#$%^&+=])(?!.*\s).{4,}$", ErrorMessage = "Your password should inculde atlest one number, one character and one special character.")]
        public string Password { get; set; }
        public virtual AddressModel Address { get; set; }
    }
}