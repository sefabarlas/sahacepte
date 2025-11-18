using System.Text.Json.Serialization;

namespace SahaCepteApp.Domain.Dtos.Facility;

public class ReservationListDto
{
    
}

public class CreateReservationDto
{
    public Guid PitchId { get; set; }
        
    [JsonIgnore]
    public Guid UserId { get; set; } 

    public DateTime MatchDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public string Note { get; set; }
}

public class ReservationResult
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public Guid? ReservationId { get; set; }
}