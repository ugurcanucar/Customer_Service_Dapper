namespace Customer_Service.DTO.Customer;

public class CustomerDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public int CityId { get; set; }
    public string Email { get; set; } = string.Empty;

    public static CustomerDto ToCustomerDto(Entities.Customer customer)
    {
        return new CustomerDto()
        {
            Id = customer.Id,
            CityId = customer.CityId,
            Email = customer.Email,
            Name = customer.Name,
            Surname = customer.Surname,
            PhoneNumber = customer.PhoneNumber
        }; 
    }

}