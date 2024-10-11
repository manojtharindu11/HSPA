using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using web_api.Interfaces;

namespace web_api.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary cloudinary;
        public PhotoService(IConfiguration configuration)
        {
            Account account = new Account(
                configuration.GetSection("CloudinarySettings:CloudName").Value,
                configuration.GetSection("CloudinarySettings:ApiKey").Value,
                configuration.GetSection("CloudinarySettings:ApiSecret").Value
                );

            cloudinary = new Cloudinary(account);
            cloudinary.Api.Secure = true;
        }
        public async Task<ImageUploadResult> UploadImageAsync(IFormFile photo)
        {
            var uplordResult = new ImageUploadResult();
            if (photo.Length > 0)
            {
                using var stream = photo.OpenReadStream();
                var uplordParams = new ImageUploadParams
                {
                    File = new FileDescription(photo.FileName, stream),
                    Transformation = new Transformation()
                        .Height(500).Width(800)
                };
                uplordResult = await cloudinary.UploadAsync(uplordParams);
            }
            return uplordResult;
        }
    }
}
