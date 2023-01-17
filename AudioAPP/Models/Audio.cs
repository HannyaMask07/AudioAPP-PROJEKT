using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AudioAPP.Models
{
    public class Audio
    {
        [HiddenInput]
        public int Id { get; set; }
        //[Required(ErrorMessage = "Podaj tytuł")]
        public string Title { get; set; }
        [HiddenInput]
        public byte[] Image { get; set; }
        [HiddenInput]
        public byte[] Sound { get; set; }
        public string Description { get; set; }

    }
}
