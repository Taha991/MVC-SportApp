using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using SportWebApp.Helpers;
using SportWebApp.Interfaces;

namespace SportWebApp.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloundinary;

        public PhotoService(IOptions<CloudinarySettings> config)
        {
            var myacc = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
                );
            _cloundinary = new Cloudinary(myacc);
        }
        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();
            if(file.Length >0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("Face")
                };
                uploadResult = await _cloundinary.UploadAsync(uploadParams);
            }
            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            var result = await _cloundinary.DestroyAsync(deleteParams);
            return result;
        }
    }
}
