using System.ComponentModel.DataAnnotations;

namespace proiect.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public int? PacientId { get; set; }
        public Pacient? Pacient { get; set; }
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public string? Text { get; set; }

        [Range(1,5)]
        public int Rating { get; set; }
    }
}
