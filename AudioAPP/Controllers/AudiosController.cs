using AudioAPP.Data.Repository.Repository;
using AudioAPP.Models;
using Microsoft.AspNetCore.Mvc;

namespace AudioAPP.Controllers
{
    [Route("api/audios")]
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
            return _repository.FindBy(id);
        }

        // POST: api/Audios
        [HttpPost]
        public ActionResult Post([FromBody] Audio audio)
        {
            _repository.Save(audio);
            return Created("", audio);
        }

        // PUT: api/Audios/int
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Audio audio)
        {
            audio.AudioId = (int)id;
            if (_repository.Update(audio))
            {
                return BadRequest();
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
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}