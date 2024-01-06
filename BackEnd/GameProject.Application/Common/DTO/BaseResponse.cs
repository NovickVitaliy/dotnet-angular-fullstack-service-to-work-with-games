namespace GameProject.Application.Common.DTO;

public class BaseResponse<T>
{
    public string Description { get; set; } = string.Empty;
    public string[] Errors { get; set; } = Array.Empty<string>();
    public int StatusCode { get; set; }
    public T? Data { get; set; }
}