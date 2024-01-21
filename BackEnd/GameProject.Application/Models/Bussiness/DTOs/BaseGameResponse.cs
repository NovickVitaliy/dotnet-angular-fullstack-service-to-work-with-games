namespace GameProject.Application.Models.Bussiness.DTOs;

public class BaseGameResponse
{
    public string Name { get; set; } = string.Empty;
    public string BackgroundImage { get; set; } = string.Empty;
    public int RawgId { get; set; }
}