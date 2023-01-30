using AudioAPP.Data.Repository.Repository;
using AudioAPP.Models;
using Microsoft.AspNetCore.Mvc;

namespace AudioAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudiosController : ControllerBase
    {
        private IRepository _repository;
        // GET: api/Audios
        public AudiosController(IRepository bookService)
        {
            _repository = bookService;
        }

        [HttpGet]
        public IEnumerable<Audio> Get()
        {
            return _repository.FindAll();
        }

        // GET: api/Audio/int
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Audio> Get(int id)
        {
            if (_repository.FindBy(id) is null)
            {
                return NotFound();
            }
            else
            {
                return _repository.FindBy(id);
            }

        }

        // POST: api/Audios
        [HttpPost]
        public ActionResult<Audio> Post([FromBody] Audio audio)
        {
            if (audio == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            _repository.Save(audio);
            return Created("", audio);
        }

        // PUT: api/Audios/int
        [HttpPut("{id}")]
        public ActionResult<Audio> Put(int id, [FromBody] Audio audio)
        {
            audio.Id = (int)id;
            if (_repository.Update(audio))
            {
                return _repository.FindBy(id);
            }
            else
            {
                return NoContent();
            }
        }

        // DELETE: api/Audios/int
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _repository.Delete(id);
            if (result is false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}