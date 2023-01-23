using AudioAPP.Data;
using AudioAPP.Models;
using Microsoft.AspNetCore.Mvc;

namespace AudioApp.Controllers
{
    public class AudioController : Controller
    {
        private readonly IRepository _repository;

        public AudioController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var audios = _repository.GetAllAudios();
            return View(audios);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View("AudioForm");
        }
        [HttpPost]
        public async Task<IActionResult> Add(Audio audio, [FromForm(Name = "image")] IFormFile image, [FromForm(Name = "sound")] IFormFile sound)
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


                _repository.AddAudio(audio);
            if (await _repository.SaveChangesAsync())
                return RedirectToAction("Index");
            else
                return View(audio);
        }

    }
}
