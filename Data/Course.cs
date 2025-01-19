using System.ComponentModel.DataAnnotations;
using efcoreApp.Controllers;

namespace efcoreApp.Data
{
    public class Course
    {
        [Key]
        [Display(Name = "Kurs ID")]
        public int CourseId { get; set; }

        [Display(Name = "Kurs Baslığı")]
        [Required(ErrorMessage = "Başlık zorunludur!")]
        [StringLength(30, ErrorMessage = "{0} en fazala {1} karekter olabilir.")]
        public string? Title { get; set; }

        [Display(Name = "Öğretmen")]
        [Required(ErrorMessage ="{0} seçimi zorunludur!")]
        public int? TeacherId { get; set; }

        public Teacher? Teacher { get; set; }

        public ICollection<Registration> Registration { get; set; } = new List<Registration>();
    }
}