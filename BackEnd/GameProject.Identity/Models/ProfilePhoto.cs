namespace GameProject.Identity.Models;

public class ProfilePhoto
{
    public Guid Id { get; set; }
    public string PublicId { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public ApplicationUser User { get; set; } = null!;
    public Guid UserId { get; set; }
}