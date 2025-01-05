using System.ComponentModel.DataAnnotations;

namespace Budzet.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Imię i nazwisko")]
        public string? Name { get; set; }
    }
}
