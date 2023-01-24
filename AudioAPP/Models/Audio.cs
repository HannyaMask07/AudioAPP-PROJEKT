using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AudioAPP.Models
{
    public class Audio
    {
        [HiddenInput]
        public int Id { get; set; }
        //[Required(ErrorMessage = "Podaj tytuł")]
        public string ?Title { get; set; }
        public string ?Image { get; set; }
        public string ?Sound { get; set; }
        //[Required(ErrorMessage = "Proszę podać opis")]
        public string ?Description { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
