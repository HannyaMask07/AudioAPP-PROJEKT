using AudioAPP.Areas.Identity.Pages.Data;
using AudioAPP.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AudioAPP.Data.Repository.Repository
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<Repository> _logger;
        public Repository(AppDbContext context, ILogger<Repository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public Audio? Save(Audio? audio)
        {
            try
            {
                //foreach (var comment in audio.Comments)
                //{
                //    _context.Attach(comment);
                //}

                var entityEntry = _context.Audios.Add(audio);
                _context.SaveChanges();
                return entityEntry.Entity;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }
        public async Task<Audio?> SaveAsync(Audio? audio)
        {
            try
            {
                foreach (var comment in audio.Comments)
                {
                    _context.Attach(comment);
                }

                var entityEntry = _context.Audios.Add(audio);
                await _context.SaveChangesAsync();
                return entityEntry.Entity;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }


        public bool Delete(int? id)
        {
            if (id is null)
            {
                return false;
            }
            var find = _context.Audios.Find(id);
            if (find is not null)
            {
                _context.Audios.Remove(find);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Update(Audio? audio)
        {
            try
            {
                var find = _context.Audios.Find(audio.Id);
                if (find is not null)
                {
                    find.Title = audio.Title;
                    find.Description = audio.Description;
                    find.Image = audio.Image;
                    find.Sound = audio.Sound;
                    find.Author = audio.Author;
                    find.Comments = audio.Comments;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public IEnumerable<Audio?> FindAll()
        {
            return _context.Audios.Include(a => a.Comments).ToList();
        }

        public Audio? FindBy(int? id)
        {
            Audio? audio = _context.Audios.Include(a => a.Comments).FirstOrDefault(b => b.Id == id);
            _context.Entry(audio).State = EntityState.Detached;
            return id is null ? null : audio;
        }
        //public Comment? FindByAudioComment(int? id)
        //{
        //    Comment? comment = _context.Comments.FirstOrDefault(b => b.Audios.AudioId == id);
        //    _context.Entry(comment).State = EntityState.Detached;
        //    return id is null ? null : comment;
        //}
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
        public void SaveChanges()
        {

            _context.SaveChanges();
        }

        public Comment? FindByAudioComment(int? id)
        {
            throw new NotImplementedException();
        }
        public Profile? SaveProfile(Profile? profile)
        {
            try
            {
                //foreach (var comment in audio.Comments)
                //{
                //    _context.Attach(comment);
                //}

                var entityEntry = _context.Profiles.Add(profile);
                _context.SaveChanges();
                return entityEntry.Entity;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }

        public Profile? FindByProfile(int? id)
        {
            Profile? profile = _context.Profiles.FirstOrDefault(b => b.Id == id);
            _context.Entry(profile).State = EntityState.Detached;
            return id is null ? null : profile;
        }
        public bool UpdateProfile(Profile? profile)
        {
            try
            {
                var find = _context.Profiles.Find(profile.Id);
                if (find is not null)
                {
                    find.Title = profile.Title;
                    find.Description = profile.Description;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public IEnumerable<Profile?> FindAllProfiles()
        { 
            return _context.Profiles.ToList();
        }

        public Comment? SaveComment(Comment? comment)
        {
            try
            {
                //foreach (var comment in audio.Comments)
                //{
                //    _context.Attach(comment);
                //}

                var entityEntry = _context.Comments.Add(comment);
                _context.SaveChanges();
                return entityEntry.Entity;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }
    }
}
