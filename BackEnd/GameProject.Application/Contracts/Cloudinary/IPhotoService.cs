using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace GameProject.Application.Contracts.Cloudinary;

public interface IPhotoService
{
    Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
    Task<DeletionResult> DeletePhotoAsync(string publicId);
}