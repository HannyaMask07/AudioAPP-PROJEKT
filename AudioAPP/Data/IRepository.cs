using AudioAPP.Models;

namespace AudioAPP.Data
{
    public interface IRepository
    {
        Audio GetAudio(int id);
        List<Audio> GetAllAudios();
        void AddAudio(Audio audio);
        void UpdateAudio(Audio audio);
        void RemoveAudio(int id);
        Task<bool> SaveChangesAsync();
    }
}
