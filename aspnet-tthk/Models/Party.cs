using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace aspnet_tthk.Models
{
    public class Party
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Sisesta peo nimi")]
        public string Peonimi { get; set; }

        [Required(ErrorMessage = "Sisesta kuupaev")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]

        public DateTime Kuupaev { get; set; }
    }
}