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
            var audios = _repository.FindAll();
            return View(audios);
        }
        public IActionResult UserAudio()
        {
            var audios = _repository.FindAll();
            return View("UserAudio", audios);
        }
        public IActionResult Details(int? id)
        {
            var audio = _repository.FindBy(id);
            return audio is null ? NotFound() : View(audio);
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
                    Author = Autor

                };
                await _repository.SaveAsync(audio);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
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
                var audio = _repository.FindBy((int)id);
                return View(new AudioViewModel
                {
                    Id = audio.AudioId,
                    Title = audio.Title,
                    Description = audio.Description,
                    Author = audio.Author,
                    Comments = audio.Comments

                }) ;


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
                    Sound = await _fileManager.SaveSound(viewModel.Sound),
                    Author = viewModel.Author,
                    Comments = viewModel.Comments
                };
                if (audio.AudioId > 0)
                {
                    _repository.Update(audio);
                }
                else
                {
                    _repository.Save(audio);
                }
                await _repository.SaveAsync(audio);
                    return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            if (_repository.Delete(id))
            {
                await _repository.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return Problem("Trying delete no existing audio");
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
        [HttpGet]
        public IActionResult AddComment()
        {
            return View();
        }
        //[Authorize]
        //[HttpPost]
        //public async Task<IActionResult> Comment(Comment comment)
        //{
        //    var audio = _repository.FindBy(audio.AudioId);
        //    audio.Comments.Add(new Comment
        //    {
        //        Message = comment.Message,
        //    });
        //    _repository.Update(audio);
        //    await _repository.SaveAsync(audio);
        //    return RedirectToAction("Index", new { id = viewModel.AudioId });

        //}
    }
}
