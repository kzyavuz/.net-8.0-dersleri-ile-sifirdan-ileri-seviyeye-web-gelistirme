using System.ComponentModel.DataAnnotations;
using efcoreApp.Data;

namespace efcoreApp.Models
{
    public class CourseViewModel
    {

        [Key]
        [Display(Name = "Kurs ID")]
        public int CourseId { get; set; }

        [Display(Name = "Kurs Baslığı")]
        public string? Title { get; set; }

        public int? TeacherId { get; set; }
        public ICollection<Registration> Registration { get; set; } = new List<Registration>();
    }
}