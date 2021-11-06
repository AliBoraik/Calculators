using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HW7.Models
{
    public class Person
    {
        [Required]
        [MaxLength(75)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [Range(18, 200,
            ErrorMessage = "The age must be over 18 !!")]
        [DisplayName("Age")]
        public int Age { get; set; }

        [Required] [DisplayName("Gender")] public Gender Gender { get; set; }
    }

    public enum Gender
    {
        Unknown,
        Male,
        Female
    }
}