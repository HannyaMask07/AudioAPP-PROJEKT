using AudioAPP.Models;
using Microsoft.AspNetCore.Mvc;

namespace AudioApp.Controllers
{
    public class AudioController : Controller
    {

        public static List<Audio> audios = new List<Audio>();
        public static int count = 0;
        public IActionResult Index()
        {
            return View(audios);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View("AudioForm");
        }
        [HttpPost]
        public IActionResult Add(Audio audio, [FromForm(Name = "image")] IFormFile image, [FromForm(Name = "sound")] IFormFile sound)
        {
            if (sound != null)
            {
                audio.Sound = new byte[sound.Length];
                sound.OpenReadStream().Read(audio.Sound, 0, (int)sound.Length);
            }

            if (image is not null)
            {
                audio.Image = new byte[image.Length];
                image.OpenReadStream().Read(audio.Image, 0, (int)image.Length);
            }

            audio.Id = count++;

            audios.Add(audio);
            return View("Index", audios);
        }

    }
}
