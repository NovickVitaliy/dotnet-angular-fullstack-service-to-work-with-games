namespace GameProject.Domain.Models.RawgApi.Stores;

public class Store
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Games_Count { get; set; }
    public string Image_Background { get; set; }
    public string Description { get; set; }
}