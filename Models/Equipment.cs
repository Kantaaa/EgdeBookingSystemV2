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
        [StringLength(20, ErrorMessage = "Utstyrsnavnet må bestå av 3 til 20 tegn", MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(30, ErrorMessage = "Informasjonsbeskrivelse kan være opptil 30 tegn")]
        [Display(Name = "Informasjon")]
        public string Info { get; set; }

        [StringLength(20, ErrorMessage = "Serienummeret kan være opptil 20 tegn")]
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
