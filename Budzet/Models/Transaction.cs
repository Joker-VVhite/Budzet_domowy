﻿using System.ComponentModel.DataAnnotations;

namespace Budzet.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa transakcji")]
        public string? Title { get; set; }
        [Display(Name = "Kwota")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Kwota musi być większa niż zero.")]
        public decimal Amount { get; set; }
        [Display(Name = "Kategoria")]
        [Required(ErrorMessage = "Kategoria jest wymagana.")]
        public string? Category { get; set; }
        [Display(Name = "Data transakcji")]
        public DateTime Date { get; set; }
        [Display(Name = "Typ Trasakcji")]
        [Required(ErrorMessage = "Typ jest wymagany.")]
        public string? Type { get; set; } //wpłata albo wypłata
    }
}
