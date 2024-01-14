using Microsoft.EntityFrameworkCore.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace proiect.Models
{
    public class Pacient
    {
        [Key]
        public int Id { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 3)]
        public string? Nume { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 3)]
        public string? Prenume { get; set; }
        public string? Email { get; set; }

        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123' sau'0722.123.123' sau '0722 123 123'")]

        [Display(Name = "Numar Telefon")]
        public string? NumarTelefon { get; set; }

        [Display(Name = "Data Nasterii")]

        [DataType(DataType.Date)]
        public DateTime? DataNasterii { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }

    }
}
