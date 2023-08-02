namespace Customer_Service.DTO.Base;

public class ResponseModel
{
    public int StatusCode { get; set; } = 400;
    public string Message { get; set; } = string.Empty;  
}