using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Data
{
    public class Registration
    {
        [Key]
        [Display(Name = "Kayıt ID")]
        public int RegistrationId { get; set; }

        [Display(Name = "Kurs")]
        [Required(ErrorMessage ="{0} seçilmeli!")]
        public int? CourseId { get; set; }

        public Course? Course { get; set; }

        [Display(Name = "Öğrenci")]
        [Required(ErrorMessage = "{0} seçilmeli!")]
        public int? StudentId { get; set; }

        public Student? Student { get; set; }

        public DateTime RegistrationDateTime { get; set; }

    }
}
