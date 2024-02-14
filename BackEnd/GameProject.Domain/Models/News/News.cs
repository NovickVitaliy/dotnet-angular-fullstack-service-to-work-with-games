using GameProject.Domain.Models.Identity;

namespace GameProject.Domain.Models.News;

public class News
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string AuthorName { get; set; } = string.Empty;
    public DateTime DatePublished {get; set; }
    public Guid AuthorId { get; set; }
    public virtual ApplicationUser? Author { get; set; }
}