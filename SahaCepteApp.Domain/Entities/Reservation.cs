using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SahaCepteApp.Domain.Enums;

namespace SahaCepteApp.Domain.Entities;

public class Reservation : BaseEntity
{
    public Guid PitchId { get; set; }
    
    public Guid OrganizerId { get; set; }
    
    [Column(TypeName = "date")]
    public DateTime MatchDate { get; set; }

    public TimeSpan StartTime { get; set; }
    
    public TimeSpan EndTime { get; set; }
    
    public decimal TotalPrice { get; set; }

    public PaymentType PaymentType { get; set; } = PaymentType.AtVenue;
    
    public ReservationStatus Status { get; set; } = ReservationStatus.Pending;

    [MaxLength(512)]
    public string Note { get; set; }

    [MaxLength(512)]
    public string CancellationReason { get; set; }
    
    [ForeignKey("PitchId")]
    public virtual Pitch Pitch { get; set; }
    
    [ForeignKey("OrganizerId")]
    public virtual User User { get; set; }
    
    public virtual ICollection<ReservationParticipant> Participants { get; set; } = new List<ReservationParticipant>();
}