namespace GameProject.Identity.Contracts.Repositories;

public interface IPhotoRepository
{
    Task DeletePhoto(Guid photoId);
}