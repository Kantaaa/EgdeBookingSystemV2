using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EgdeBookingSystemV2.Models
{
    public class Equipment
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Utstyrsnavn er påkrevd")] //Må fylles, med min og maks tegn.
        [Display(Name = "Utstyrsnavn")]
        [StringLength(50, ErrorMessage = "Utstyrsnavnet må bestå av 3 til 50 tegn", MinimumLength = 3)]
        public string Name { get; set; }


        [Display(Name = "Informasjon")]
        public string Info { get; set; }

        [Display(Name = "Serienummer")]
        public string ModelNumber { get; set; }

        [Required] //Oprettet objekter fra andre klasser for å få tilgang til å hente data(felter) fra de.
        [Display(Name = "Kategori")]
        public int CategoryID { get; set; }
        [Display(Name = "Kategori")]
        public Category Category { get; set; }

        [Required]
        [Display(Name = "Lokasjon")]
        public int LocationID { get; set; }
        public Location Location { get; set; }

        public ICollection<Booking> Bookings { get; set; }
        
    }
}
