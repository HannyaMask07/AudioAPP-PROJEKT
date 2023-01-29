using AudioAPP.Models;

namespace AudioAPP.Data.Repository.Repository
{
    public interface IRepository
    {
        public Audio? Save(Audio? audio);
        public Task<Audio?> SaveAsync(Audio? audio);
        public bool Delete(int? id);
        public bool Update(Audio? audio);
        public Audio? FindBy(int? id);
        public IEnumerable<Audio?> FindAll();
        public Comment? FindByAudioComment(int? id);
        Task<bool> SaveChangesAsync();
        public Profile? SaveProfile(Profile? profile);
        public Profile? FindByProfile(int? id);
        public bool UpdateProfile(Profile? profile);
        public IEnumerable<Profile?> FindAllProfiles();

        //Audio GetAudio(int id);
        //List<Audio> GetAllAudios();
        //void AddAudio(Audio audio);
        //void UpdateAudio(Audio audio);
        ////void AddComment(Comment comment);
        //void RemoveAudio(int id);
        //Task<bool> SaveChangesAsync();
    }
}
