using AudioAPP.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AudioAPP.ViewModels
{
    public class ProfileViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Proszę podać tytuł")]
        [MinLength(2, ErrorMessage = "Długość tytułu musi wynosić więcej niż 2 znaki")]
        [MaxLength(100, ErrorMessage = "Długość tytułu nie może wynosić więcej niż 15 znaków")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Proszę podać tytuł")]
        [MinLength(10, ErrorMessage = "Długość posta musi wynosić więcej niż 10 znaków")]
        [MaxLength(100, ErrorMessage = "Długość posta nie może wynosić więcej niż 100 znaków")]
        public string? Description { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string? Author { get; set; }
        public Priority Priorities { get; set; }
    }
}
