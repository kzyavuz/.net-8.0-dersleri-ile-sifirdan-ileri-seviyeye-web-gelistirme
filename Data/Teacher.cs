using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Data
{
    public class Teacher
    {
        [Key]
        [Display(Name ="Öðretmen ID")]
        public int TeacherId { get; set; }

        [Display(Name = "Öðretmen Adý")]
        [Required(ErrorMessage = "{0} zorunludur!")]
        [StringLength(50, ErrorMessage = "{0} en fazla {1} karekter olabilir.")]
        public string? Name { get; set; }

        [Display(Name = "Öðretmen Soyadý")]
        [Required(ErrorMessage = "{0} zorunludur!")]
        [StringLength(50, ErrorMessage = "{0} en fazla {1} karekter olabilir.")]
        public string? Surname { get; set; }

        [Display(Name = "Öðretmen Ad Soyad")]
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

        [Display(Name = "Telefon Numarasý")]
        [Required(ErrorMessage = "{0} zorunludur!")]
        [StringLength(11, ErrorMessage = "{0} en fazla {1} karekter olabilir.")]
        public string? Phone { get; set; }

        [Display(Name = "Cinsiyet")]
        [Required(ErrorMessage = "{0} zorunludur!")]
        public string? Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name ="Baslangýç Tarihi")]
        [Required(ErrorMessage = "{0} zorunludur!")]
        public DateTime? StartDateTime { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();

    }
}