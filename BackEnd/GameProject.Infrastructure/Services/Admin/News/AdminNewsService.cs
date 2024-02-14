using GameProject.Application.Contracts.Admin;
using GameProject.Application.Models.Admin.News;
using GameProject.Domain.Models.Identity;
using GameProject.Identity.DbContext;
using Microsoft.EntityFrameworkCore;

namespace GameProject.Identity.Services.Admin.News;

public class AdminNewsService : IAdminNewsService
{
    private readonly ApplicationIdentityDbContext _db;

    public AdminNewsService(ApplicationIdentityDbContext db)
    {
        _db = db;
    }

    public async Task PublishNews(PublishNewsRequest publishNewsRequest)
    {
        var admin = await GetAdmin(publishNewsRequest.Author);

        Domain.Models.News.News news = new()
        {
            Title = publishNewsRequest.Title,
            Content = publishNewsRequest.Content,
            AuthorName = publishNewsRequest.Author,
            DatePublished = DateTime.UtcNow,
            Author = admin,
            AuthorId = admin.Id
        };

        admin.PublishedNews.Add(news);
        await _db.News.AddAsync(news);
        await _db.SaveChangesAsync();
    }

    private async Task<ApplicationUser> GetAdmin(string author)
    {
        return await _db.Users.SingleAsync(u => u.Email == author);
    }
}