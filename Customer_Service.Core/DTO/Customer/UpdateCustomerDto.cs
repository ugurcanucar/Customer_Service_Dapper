namespace Customer_Service.DTO.Customer;

public class UpdateCustomerDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public int CityId { get; set; }
}