using Microsoft.AspNetCore.Mvc;

namespace AudioAPP.ViewModels
{
    public class AudioViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
        //[Required(ErrorMessage = "Podaj tytuł")]
        public string? Title { get; set; }
        public IFormFile? Image { get; set; }
        public IFormFile? Sound { get; set; }
        //[Required(ErrorMessage = "Proszę podać opis")]
        public string? Description { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
