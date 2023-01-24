namespace AudioAPP.Data.FileManager
{
    public interface IFileManager
    {
        FileStream ImageStream(string image);
        FileStream SoundStream(string sound);
        Task<string> SaveImage(IFormFile image);
        Task<string> SaveSound(IFormFile sound);
    }
}
