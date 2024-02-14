using GameProject.Application.Models.Admin.News;

namespace GameProject.Application.Contracts.Admin;

public interface IAdminNewsService
{
    Task PublishNews(PublishNewsRequest publishNewsRequest);
}