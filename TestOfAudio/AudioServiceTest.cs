using AudioAPP.Areas.Identity.Pages.Data;
using AudioAPP.Data.Repository.Repository;
using AudioAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOfAudio
{
    internal class AudioServiceTest : IRepository
    {
        private Dictionary<int, Audio> _context = new Dictionary<int, Audio>();
        private int index;

        public bool Delete(int? id)
        {
            if(id == null)
                return false;
            return _context.Remove((int)id);
        }

        public bool DeleteProfilePost(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Audio?> FindAll()
        {
            return _context.Values;
        }

        public IEnumerable<Profile?> FindAllProfiles()
        {
            throw new NotImplementedException();
        }

        public Audio? FindBy(int? id)
        {
            if (id == null)
            {
                return null;
            }
            _context.TryGetValue((int)id, out Audio? audio);
            return audio;
        }

        public Comment? FindByAudioComment(int? id)
        {
            throw new NotImplementedException();
        }

        public Profile? FindByProfile(int? id)
        {
            throw new NotImplementedException();
        }

        public Audio? Save(Audio? audio)
        {
            audio.Id = nextIndex();
            _context.Add(audio.Id, audio);
            return audio;
        }

        public Task<Audio?> SaveAsync(Audio? audio)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Comment? SaveComment(Comment? comment)
        {
            throw new NotImplementedException();
        }

        public AudioLike? SaveLike(AudioLike? audioLike)
        {
            throw new NotImplementedException();
        }

        public Profile? SaveProfile(Profile? profile)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Audio?> SearchFind(string search)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Profile?> SearchFindProfile(string search)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Profile?> TagFindProfile(int tag)
        {
            throw new NotImplementedException();
        }

        public bool Update(Audio? audio)
        {
            if (_context.ContainsKey(audio.Id))
            {
                _context[audio.Id] = audio;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateProfile(Profile? profile)
        {
            throw new NotImplementedException();
        }
        private int nextIndex()
        {
            return ++index;
        }
    }
}
