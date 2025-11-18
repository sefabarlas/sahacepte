using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SahaCepteApp.Domain.Entities;

public class Facility: BaseEntity
{
    public Guid OwnerId { get; set; }
    
    [Required]
    [MaxLength(256)]
    public string Name { get; set; }

    [MaxLength(512)]
    public string Description { get; set; }

    [Required]
    [MaxLength(32)]
    public string PhoneNumber { get; set; }

    public int CityId { get; set; }
    
    public int DistrictId { get; set; }
        
    [Required]
    [MaxLength(512)]
    public string Address { get; set; }

    public double Latitude { get; set; }
    
    public double Longitude { get; set; }

    [MaxLength(int.MaxValue)]
    [Column(TypeName = "jsonb")] 
    public string Amenities { get; set; } 
    
    [MaxLength(int.MaxValue)]
    [Column(TypeName = "jsonb")]
    public string ImageUrls { get; set; }
    
    [ForeignKey("OwnerId")]
    public virtual FacilityOwner FacilityOwner { get; set; }
    
    public virtual ICollection<Pitch> Pitches { get; set; } = new List<Pitch>();
}