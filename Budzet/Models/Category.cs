using System.ComponentModel.DataAnnotations;

namespace Budzet.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Nazwa kategorii")]
        public string? Name { get; set; }
    }
}
