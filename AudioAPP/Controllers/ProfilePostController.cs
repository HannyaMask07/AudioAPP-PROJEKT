using AudioAPP.Data.FileManager;
using AudioAPP.Data.Repository.Repository;
using AudioAPP.Models;
using AudioAPP.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AudioAPP.Controllers
{
    public class ProfilePostController : Controller
    {
        private readonly IRepository _repository;
        private readonly IFileManager _fileManager;
        private UserManager<IdentityUser> _userManager;

        public ProfilePostController(IRepository repository, IFileManager fileManager, UserManager<IdentityUser> userManager)
        {
            _repository = repository;
            _fileManager = fileManager;
            _userManager = userManager;
        }
        [Authorize]
        public IActionResult Index()
        {
            var profilePosts = _repository.FindAllProfiles();
            return View(profilePosts);
        }
        [Authorize]
        [HttpGet]
        public IActionResult TagFindProfile1(string id)
        {
            int tag = 1;
            var profilePosts = _repository.TagFindProfile(tag);
            return View("Index", profilePosts);
        }
        [Authorize]
        [HttpGet]
        public IActionResult TagFindProfile2(string id)
        {
            int tag = 2;
            var profilePosts = _repository.TagFindProfile(tag);
            return View("Index", profilePosts);
        }
        [Authorize]
        [HttpGet]
        public IActionResult TagFindProfile3(string id)
        {
            int tag = 3;
            var profilePosts = _repository.TagFindProfile(tag);
            return View("Index", profilePosts);
        }
        [Authorize]
        [HttpGet]
        public IActionResult TagFindProfile4(string id)
        {
            int tag = 4;
            var profilePosts = _repository.TagFindProfile(tag);
            return View("Index", profilePosts);
        }
        [HttpGet]
        public IActionResult SearchFind(string search)
        {
            var profiles = _repository.SearchFindProfile(search);
            return View("Index", profiles);
        }
        public IActionResult Details(int? id)
        {
            var profilePost = _repository.FindByProfile(id);
            return profilePost is null ? NotFound() : View(profilePost);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(ProfileViewModel viewModel)
        {
            var Autor = _userManager.GetUserName(User);

            if (ModelState.IsValid)
            {
                var profilePost = new Profile
                {
                    Id = viewModel.Id,
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    Author = Autor,
                    Priorities = viewModel.Priorities

                };
                _repository.SaveProfile(profilePost);
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
                return View(new ProfileViewModel());
            }
            else
            {
                var profilePost = _repository.FindByProfile((int)id);
                return View(new ProfileViewModel
                {
                    Id = profilePost.Id,
                    Title = profilePost.Title,
                    Description = profilePost.Description,
                    Author = profilePost.Author,
                    Priorities = profilePost.Priorities

                });


            }

        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(ProfileViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var profilePost = new Profile
                {
                    Id = viewModel.Id,
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    Author = viewModel.Author,
                    Priorities = viewModel.Priorities
                };
                if (profilePost.Id > 0)
                {
                    _repository.UpdateProfile(profilePost);
                }
                else
                {
                    _repository.SaveProfile(profilePost);
                }
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
            if (_repository.DeleteProfilePost(id))
            {
                await _repository.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return Problem("Trying delete no existing profile post");
        }

    }
}
