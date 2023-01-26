namespace AudioAPP.Data.FileManager
{
    public class FileManager : IFileManager
    {
        private string _imagePath;
        private string _soundPath;
        public FileManager(IConfiguration config)
        {
            _imagePath = config["Path:Images"];
            _soundPath = config["Path:Sounds"];
        }
        public FileStream SoundStream(string sound)
        {
            return new FileStream(Path.Combine(_soundPath, sound), FileMode.Open, FileAccess.Read);
        }
        public FileStream ImageStream(string image)
        {
            return new FileStream(Path.Combine(_imagePath, image),FileMode.Open, FileAccess.Read);
        }

        public async Task<string> SaveImage(IFormFile image)
        {
            if(image is not null)
            {
                var save_path = Path.Combine(_imagePath);
                if (!Directory.Exists(save_path))
                {
                    Directory.CreateDirectory(save_path);
                }
                var mime = image.FileName.Substring(image.FileName.LastIndexOf('.'));
                var fileName = $"img_{DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")}{mime}";

                using (var fileStream = new FileStream(Path.Combine(save_path, fileName), FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

                return fileName;
            }
            else
            {
                var fileName = "unnamed.png";
                return fileName;
            }
        }

        public async Task<string> SaveSound(IFormFile sound)
        {
            if (sound is not null)
            {
                var save_path = Path.Combine(_soundPath);
                if (!Directory.Exists(save_path))
                {
                    Directory.CreateDirectory(save_path);
                }
                var mime = sound.FileName.Substring(sound.FileName.LastIndexOf('.'));
                var fileName = $"sound_{DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")}{mime}";

                using (var fileStream = new FileStream(Path.Combine(save_path, fileName), FileMode.Create))
                {
                    await sound.CopyToAsync(fileStream);
                }

                return fileName;
            }
            else
            {
                var fileName = "unnamed.wav";
                return fileName;
            }
        }


    }
}
