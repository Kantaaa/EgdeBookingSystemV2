using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EgdeBookingSystemV2.Models
{
    public class Booking
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Brukernavn")]
        [StringLength(100, MinimumLength = 3)]
        public string UserEmail { get; set; }
        [Required(ErrorMessage = "Vennligst spesifiser startdato")]
        [Display(Name = "Startdato")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Vennligst spesifiser sluttdato")]
        [Display(Name = "Sluttdato")]
        public DateTime EndDate { get; set; }
        [Required]
        public int EquipmentID { get; set; }
        public Equipment Equipment { get; set; }
    }
}


