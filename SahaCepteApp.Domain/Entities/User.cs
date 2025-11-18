using System.ComponentModel.DataAnnotations;

namespace SahaCepteApp.Domain.Entities;

public class User : BaseEntity
{
    [Required]
    [MaxLength(32)]
    public string PhoneNumber { get; set; }

    [Required]
    [MaxLength(128)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(128)]
    public string LastName { get; set; }

    [MaxLength(128)]
    public string Email { get; set; }

    [MaxLength(512)]
    public string AvatarUrl { get; set; }

    public bool IsSystemAdmin { get; set; }
    
    public DateTime? LastLoginDate { get; set; }
    
    public string FullName => $"{FirstName} {LastName}";
    
    public virtual Player Player { get; set; }

    public virtual FacilityOwner FacilityOwner { get; set; }
    
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}