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
        public byte[] ?Image { get; set; }
        public byte[] ?Sound { get; set; }
        //[Required(ErrorMessage = "Proszę podać opis")]
        public string ?Description { get; set; }

    }
}
