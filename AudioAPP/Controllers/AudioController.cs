using AudioAPP.Data.FileManager;
using AudioAPP.Data.Repository.Repository;
using AudioAPP.Models;
using AudioAPP.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AudioApp.Controllers
{
    
    public class AudioController : Controller
    {
        private readonly IRepository _repository;
        private readonly IFileManager _fileManager;
        private UserManager<IdentityUser> _userManager;

        public AudioController(IRepository repository, IFileManager fileManager, UserManager<IdentityUser> userManager)
        {
            _repository = repository;
            _fileManager = fileManager;
            _userManager = userManager;
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
        [Authorize]
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
                    Id = audio.AudioId,
                    Title = audio.Title,
                    Description = audio.Description

                });


            }

        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(AudioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var audio = new Audio
                {
                    AudioId = viewModel.Id,
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    Image = await _fileManager.SaveImage(viewModel.Image),
                    Sound = await _fileManager.SaveSound(viewModel.Sound)
                };

                if (audio.AudioId > 0)
                {
                    _repository.UpdateAudio(audio);
                }
                else
                {
                    _repository.AddAudio(audio);
                }

                if (await _repository.SaveChangesAsync())
                    return RedirectToAction("Index");
                else
                    return View(audio);
            }
            else
            {
                return View();
            }
        }
        [Authorize]
        [HttpGet]
        public async Task <IActionResult> Remove(int id)
        {
           _repository.RemoveAudio(id);
            await _repository.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(AudioViewModel viewModel)
        {
            var Autor = _userManager.GetUserName(User);

            if (ModelState.IsValid)
            {
                var audio = new Audio
                {
                    AudioId = viewModel.Id,
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    Image = await _fileManager.SaveImage(viewModel.Image),
                    Sound = await _fileManager.SaveSound(viewModel.Sound),
                    Author = {Name = Autor}
                };
                _repository.AddAudio(audio);
          

                if (await _repository.SaveChangesAsync())
                    return RedirectToAction("Index");
                else
                    return View(audio);
            }
            else
            {
                return View();
            }
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
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Comment(CommentViewModel viewModel)
        {

            if (!ModelState.IsValid)
                return RedirectToAction("Index", new { id = viewModel.AudioId});

            var audio = _repository.GetAudio(viewModel.AudioId);
            audio.Comments = audio.Comments ?? new List<Comment>();
            audio.Comments.Add(new Comment
            {
                Message = viewModel.Message,
            });
            var comments = audio.Comments.Count();

            _repository.UpdateAudio(audio);
            await _repository.SaveChangesAsync();
            return RedirectToAction("Index", new { id = viewModel.AudioId });

        }
    }
}
