using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment_2.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        [Required(), MaxLength(60), MinLength(2)]
        [Display(Name = "First Name")]
        public string Name { get; set; }
        [Required(), MaxLength(60), MinLength(2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? Salary { get; set; }

    }
}