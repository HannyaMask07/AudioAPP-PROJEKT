using AudioAPP.Data.FileManager;
using AudioAPP.Data.Repository.Repository;
using AudioAPP.Models;
using AudioAPP.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AudioApp.Controllers
{
    public class AudioController : Controller
    {
        private readonly IRepository _repository;
        private readonly IFileManager _fileManager;

        public AudioController(IRepository repository, IFileManager fileManager)
        {
            _repository = repository;
            _fileManager = fileManager;
        }


        public IActionResult Index()
        {
            var audios = _repository.GetAllAudios();
            return View(audios);
        }
        public IActionResult Audio(int id)
        {
            var audio = _repository.GetAudio(id);
            return View(audio);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View(new AudioViewModel());
            }
            else
            {
                var audio = _repository.GetAudio((int)id);
                return View(new AudioViewModel
                {
                    Id = audio.Id,
                    Title = audio.Title,
                    Description = audio.Description

                });


            }

        }
        [HttpPost]
        public async Task<IActionResult> Edit(AudioViewModel viewModel)
        {
            var audio = new Audio
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                Description = viewModel.Description,
                Image = await _fileManager.SaveImage(viewModel.Image),
                Sound = await _fileManager.SaveSound(viewModel.Sound)
            };

            if (audio.Id > 0)
            {
                _repository.UpdateAudio(audio);
            }
            else
            {
                _repository.AddAudio(audio);
            }

            if(await _repository.SaveChangesAsync())
                return RedirectToAction("Index");
            else
                return View(audio);
        }
        [HttpGet]
        public async Task <IActionResult> Remove(int id)
        {
           _repository.RemoveAudio(id);
            await _repository.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View("Create");
        }
        [HttpPost]
        public async Task<IActionResult> Add(Audio audio)
        {

                _repository.AddAudio(audio);
            if (await _repository.SaveChangesAsync())
                return RedirectToAction("Index");
            else
                return View(audio);
        }
        [HttpGet("/Image/{image}")]
        public IActionResult Image(string image)
        {
            var mime = image.Substring(image.LastIndexOf('.') + 1);
            return new FileStreamResult(_fileManager.ImageStream(image), $"image/{mime}");
        }
        [HttpGet("/Sound/{sound}")]
        public IActionResult Sound(string sound)
        {
            var mime = sound.Substring(sound.LastIndexOf('.') + 1);
            return new FileStreamResult(_fileManager.SoundStream(sound), $"sound/{mime}");
        }
    }
}
