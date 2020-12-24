using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElectionWebApp.Models
{
    public class CastVote
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Input Voter ID"), Display(Name = "Voter ID")]
        public int VoterId { get; set; }

        [Required(ErrorMessage = "Please Select a Symbol"), Display(Name = "Select Symbol  ")]
        public int SymbolId { get; set; }
        public string SymbolName { get; set; }
    }
}