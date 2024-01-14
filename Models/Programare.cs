using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace proiect.Models
{
    public class Programare
    {
        [Key]
        public int Id { get; set; }

        public int? PacientId { get; set; }
        public Pacient? Pacient { get; set; }
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        [Display(Name = "Data Programarii")]
        [DataType(DataType.DateTime)]
        public DateTime? DataProgramarii { get; set; }
    }
}
