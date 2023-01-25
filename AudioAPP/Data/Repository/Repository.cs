using AudioAPP.Areas.Identity.Pages.Data;
using AudioAPP.Models;
using System.Linq;

namespace AudioAPP.Data.Repository.Repository
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public void AddAudio(Audio audio)
        {
            _context.Audios.Add(audio);
        }

        public List<Audio> GetAllAudios()
        {
            return _context.Audios.ToList();
        }

        public Audio GetAudio(int id)
        {
            return _context.Audios.FirstOrDefault(x => x.Id == id);
        }

        public void RemoveAudio(int id)
        {
            _context.Audios.Remove(GetAudio(id));
        }

        public void UpdateAudio(Audio audio)
        {
            _context.Audios.Update(audio);
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
