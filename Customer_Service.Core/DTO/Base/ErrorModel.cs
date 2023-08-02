namespace Customer_Service.DTO.Base;

public class ErrorModel
{
    public int StatusCode { get; set; } = 400;
    public string Message { get; set; } = string.Empty;  
    public IEnumerable<string>? Errors { get; set; }
}