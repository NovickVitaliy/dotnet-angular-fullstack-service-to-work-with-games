namespace GameProject.Application.Common.DTO;

public class BaseResponse<T>
{
    public string Description { get; set; } = string.Empty;
    public T? Data { get; set; }
}