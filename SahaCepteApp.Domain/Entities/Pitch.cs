using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SahaCepteApp.Domain.Enums;

namespace SahaCepteApp.Domain.Entities;

public class Pitch: BaseEntity
{
    public Guid FacilityId { get; set; }

    [Required]
    [MaxLength(256)]
    public string Name { get; set; } 
    
    public PitchType Type { get; set; } = PitchType.Outdoor;
    
    public SurfaceType Surface { get; set; } = SurfaceType.ArtificialTurf;

    public PitchStatus Status { get; set; } = PitchStatus.Available;

    public int Width { get; set; } 
    
    public int Length { get; set; }

    public int Capacity { get; set; } = 14; 
        
    public decimal PricePerHour { get; set; }

    public TimeSpan OpeningTime { get; set; } = new TimeSpan(9, 0, 0);
    
    public TimeSpan ClosingTime { get; set; } = new TimeSpan(3, 0, 0);
    
    [ForeignKey("FacilityId")]
    public virtual Facility Facility { get; set; }
}