namespace GameProject.Application.Models.Shared;

public class PagedResult<T>
{
    public int TotalCount { get; set; }
    public int CurrentPage { get; set; }
    public int ItemsPerPage { get; set; }
    public List<T> Items { get; set; }
}