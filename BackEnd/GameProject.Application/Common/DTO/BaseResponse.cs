namespace GameProject.Application.Common.DTO;

public class BaseResponse<T>
{
    public string Description { get; set; } = string.Empty;
    public int StatusCode { get; set; }
    public T? Data { get; set; }
    
}