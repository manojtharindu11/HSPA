using CloudinaryDotNet.Actions;

namespace web_api.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> UploadImageAsync(IFormFile photo);
    }
}
