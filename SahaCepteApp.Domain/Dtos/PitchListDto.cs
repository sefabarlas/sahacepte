namespace SahaCepteApp.Domain.Dtos.Facility;

public class PitchListDto
{
    
}

public class TimeSlotDto
{
    public string Time { get; set; }
    public string Status { get; set; }
    public decimal Price { get; set; }
    public bool IsPast { get; set; }
}