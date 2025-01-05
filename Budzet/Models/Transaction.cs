using System.ComponentModel.DataAnnotations;

namespace Budzet.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa transakcji")]
        public string? Title { get; set; }
        [Display(Name = "Kwota")]
        public decimal Amount { get; set; }
        [Display(Name = "Kategoria")]
        public string? Category { get; set; }
        [Display(Name = "Data transakcji")]
        public DateTime Date { get; set; }
        [Display(Name = "Typ Trasakcji")]
        public string? Type { get; set; } //wpłata albo wypłata
    }
}
