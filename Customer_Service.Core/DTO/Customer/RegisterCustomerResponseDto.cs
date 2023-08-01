namespace Customer_Service.DTO.Customer;

public class RegisterCustomerResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public int CityId { get; set; }
    public string Email { get; set; } = string.Empty; 

    public static RegisterCustomerResponseDto fromEntity(Entities.Customer customer)
    {
        return new RegisterCustomerResponseDto()
        {
            Id = customer.Id,
            Name = customer.Name,
            Surname = customer.Surname,
            PhoneNumber = customer.PhoneNumber,
            CityId = customer.CityId,
            Email = customer.Email, 
        
        };
    }
}