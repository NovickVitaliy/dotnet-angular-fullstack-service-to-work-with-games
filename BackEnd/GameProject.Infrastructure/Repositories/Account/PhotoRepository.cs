using GameProject.Domain.Models.Identity;
using GameProject.Identity.Contracts.Repositories;
using GameProject.Identity.DbContext;
using GameProject.Identity.Models;

namespace GameProject.Identity.Repositories;

public class PhotoRepository : IPhotoRepository
{
    private readonly ApplicationIdentityDbContext _db;

    public PhotoRepository(ApplicationIdentityDbContext db)
    {
        _db = db;
    }

    public async Task DeletePhoto(Guid photoId)
    {
        var profilePhoto = _db.Set<ProfilePhoto>().Find(photoId);
        _db.Set<ProfilePhoto>().Remove(profilePhoto!);
        await _db.SaveChangesAsync();
    }
}