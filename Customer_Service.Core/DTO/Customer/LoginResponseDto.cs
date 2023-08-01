namespace Customer_Service.DTO.Customer;

public class LoginResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public int CityId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;

    public static LoginResponseDto fromEntity(Entities.Customer customer)
    {
        return new LoginResponseDto()
        {
            Name = customer.Name,
            Email = customer.Email,
            Id = customer.Id,
            Surname = customer.Surname,
            Token = "",
            CityId = customer.CityId,
            PhoneNumber = customer.PhoneNumber
        };
    }
}