using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElectionWebApp.Models
{
    public class Candidate
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Input Candidate's Name"), StringLength(30, MinimumLength = 2), Display(Name = "Candidate Name  ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Input a Symbol"), StringLength(20, MinimumLength = 2), Display(Name = "Symbol")]
        public string Symbol { get; set; }
        public int Vote { get; set; }
    }
}