namespace SahaCepteApp.Domain.Dtos.Facility;

public class FacilityListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string CityName { get; set; }
    public string DistrictName { get; set; }
    public decimal MinPrice { get; set; }
    public string ImageUrl { get; set; }
    public double Rating { get; set; }
}

public class FacilityDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public List<string> Amenities { get; set; }
    public List<string> ImageUrls { get; set; }
    public List<FacilityDetailPitchDto> Pitches { get; set; }
}

public class FacilityDetailPitchDto 
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; } // Kapalı/Açık
    public decimal Price { get; set; }
}

public class FacilityFilterDto
{
    public int? CityId { get; set; }
    public int? DistrictId { get; set; }
    public string[] Amenities { get; set; }
}