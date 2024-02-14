using GameProject.Application.Contracts.Admin;
using GameProject.Application.Models.Admin.News;
using Microsoft.AspNetCore.Mvc;

namespace GameProject.API.Controllers.Admin;

[ApiController]
[Route("api/admin-news")]
public class AdminNewsController : ControllerBase
{
    private readonly IAdminNewsService _adminNewsService;

    public AdminNewsController(IAdminNewsService adminNewsService)
    {
        _adminNewsService = adminNewsService;
    }

    [HttpPost]
    public async Task<ActionResult> Publish(PublishNewsRequest publishNewsRequest)
    {
        await _adminNewsService.PublishNews(publishNewsRequest);
        return Ok();
    }
}