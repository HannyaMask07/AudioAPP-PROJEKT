﻿using AudioAPP.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AudioAPP.ViewModels
{
    public class AudioViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Proszę podać tytuł")]
        public string? Title { get; set; }
        public IFormFile? Image { get; set; }
        [Required(ErrorMessage = "Proszę dodac plik audio")]
        public IFormFile? Sound { get; set; }
        [Required(ErrorMessage = "Proszę podać opis")]
        public string? Description { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public ICollection<Comment>? Comments { get; set; }

    }
}
