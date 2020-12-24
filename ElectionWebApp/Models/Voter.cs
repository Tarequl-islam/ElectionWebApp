using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElectionWebApp.Models
{
    public class Voter
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Input Voter's Name"), StringLength(30, MinimumLength = 2), Display(Name = "Voter Name  ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Input a Voter ID"), Display(Name = "Voter ID")]
        public int VoterId { get; set; }
    }
}