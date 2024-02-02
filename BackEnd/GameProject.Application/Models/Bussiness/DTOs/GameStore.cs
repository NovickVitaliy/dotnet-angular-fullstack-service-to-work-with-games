namespace GameProject.Application.Models.Bussiness.DTOs;

public class GameStore
{
    public int Id { get; set; }
    public int Game_Id { get; set; }
    public int Store_Id { get; set; }
    public string Url { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}