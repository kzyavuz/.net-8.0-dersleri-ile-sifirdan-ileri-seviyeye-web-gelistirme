using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Data
{
    public class Student
    {
        [Key]
        [Display(Name = "Öğrenci ID")]
        public int StudentId { get; set; }

        [Display(Name = "Öğrenci Adı")]
        [Required(ErrorMessage ="{0} zorunludur!")]
        [StringLength(50,ErrorMessage ="{0} en fazla {1} karekter olabilir.")]
        public string? Name { get; set; }

        [Display(Name = "Öğrenci Soyadı")]
        [Required(ErrorMessage = "{0} zorunludur!")]
        [StringLength(50, ErrorMessage = "{0} en fazla {1} karekter olabilir.")]
        public string? Surname { get; set; }

        [Display(Name = "Öğrenci Ad Soyad")]
        public string FullName
        {
            get
            {
                return this.Name + " " + this.Surname;
            }
        }

        [Display(Name = "E-Posta")]
        [Required(ErrorMessage = "{0} zorunludur!")]
        public string? Email { get; set; }

        [Display(Name = "Telefon Numarası")]
        [Required(ErrorMessage = "{0} zorunludur!")]
        [StringLength(11, ErrorMessage = "{0} en fazla {1} karekter olabilir.")]
        public string? Phone { get; set; }

        [Display(Name = "Cinsiyet")]
        [Required(ErrorMessage = "{0} zorunludur!")]
        public string? Gender { get; set; }

        public ICollection<Registration> Registration { get; set; } = new List<Registration>();
    }
}