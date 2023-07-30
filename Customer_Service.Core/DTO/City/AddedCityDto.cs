namespace Customer_Service.DTO.City;

public class AddedCityDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public static AddedCityDto ToAddedCityDto(Entities.City city)
    {
        return new AddedCityDto()
        {
         Id   = city.Id,
         Name = city.Name,
        };
    }
}