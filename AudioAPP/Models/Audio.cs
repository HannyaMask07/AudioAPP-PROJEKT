﻿using AudioAPP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AudioAPP.Models
{
    public class Audio
    {
        public Audio()
        {
            Comments = new List<Comment>();
        }
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Proszę podać tytuł")]
        public string? Title { get; set; }
        public string ?Image { get; set; }
        [Required(ErrorMessage= "Proszę dodac plik audio")]
        public string? Sound { get; set; }
        [Required(ErrorMessage = "Proszę podać opis")]
        public string? Description { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string? Author { get; set; }


        public List<Comment> Comments { get; set; }
    }
}
