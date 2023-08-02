namespace Customer_Service.DTO.City;

public class UpdateCityDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public static UpdateCityDto? ToUpdateCityDto(Entities.City? cities)
    {
        if (cities == null) return null;
        return new UpdateCityDto()
        {
            Id = cities.Id,
            Name = cities.Name
        };
    }
    
}