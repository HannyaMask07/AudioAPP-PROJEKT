using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AudioAPP.Models
{
    public class Profile
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Proszę podać tytuł")]
        [MinLength(10, ErrorMessage = "Długość tytułu musi wynosić więcej niż 2 znaki")]
        [MaxLength(100, ErrorMessage = "Długość tytułu nie może wynosić więcej niż 15 znaków")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Proszę podać tytuł")]
        [MinLength(10, ErrorMessage = "Długość posta musi wynosić więcej niż 10 znaków")]
        [MaxLength(100, ErrorMessage = "Długość posta nie może wynosić więcej niż 100 znaków")]
        public string? Description { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string? Author { get; set; }
        //public Priority Priorities { get; set; }
        //public enum Priority
        //{
        //    [Display(Name = "Niski")] Low = 1,
        //    [Display(Name = "Normalny")] Normal = 2,
        //    [Display(Name = "Wysoki")] High = 3,
        //    [Display(Name = "Pilny")] Urgent = 4
        //}

    }
}
