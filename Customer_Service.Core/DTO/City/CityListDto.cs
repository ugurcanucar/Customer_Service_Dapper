namespace Customer_Service.DTO.City;

public class CityListDto
{
    public int Id { get; set; }
    public string Name { get; set; }=string.Empty;


    public static CityListDto? ToCityListDto(Entities.City? cities)
    {
        if (cities == null) return null;
        return new CityListDto()
        {
            Id = cities.Id,
            Name = cities.Name
        };
    }

}