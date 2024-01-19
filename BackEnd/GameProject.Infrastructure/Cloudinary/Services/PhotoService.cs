using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using GameProject.Application.Contracts.Cloudinary;
using GameProject.Application.Exceptions;
using GameProject.Infrastructure.Cloudinary.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace GameProject.Infrastructure.Cloudinary.Services;

public class PhotoService : IPhotoService
{
    private readonly CloudinaryDotNet.Cloudinary _cloudinary;

    public PhotoService(IOptions<CloudinarySettings> cloudinaryOptions)
    {
        Account account = new Account(
            cloudinaryOptions.Value.CloudName,
            cloudinaryOptions.Value.ApiKey,
            cloudinaryOptions.Value.ApiSecret);

        _cloudinary = new CloudinaryDotNet.Cloudinary(account);
    }
    
    public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
    {
        if (file.Length > 0)
        {
            using var imageStream = file.OpenReadStream();
            ImageUploadParams imageUploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.Name, imageStream),
                Transformation = new Transformation()
                    .Height(500)
                    .Width(500)
                    .Crop("fill")
                    .Gravity("face"),
                Folder = "game-project"
            };

            var imageUploadResult = await _cloudinary.UploadAsync(imageUploadParams);
            
            return imageUploadResult;
        }
        throw new BadRequestException("File is empty");
    }

    public async Task<DeletionResult> DeletePhotoAsync(string publicId)
    {
        DeletionParams deletionParams = new DeletionParams(publicId);
        return await _cloudinary.DestroyAsync(deletionParams);
    }
}