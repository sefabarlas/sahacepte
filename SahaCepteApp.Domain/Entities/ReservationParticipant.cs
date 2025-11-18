using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SahaCepteApp.Domain.Enums;

namespace SahaCepteApp.Domain.Entities;

public class ReservationParticipant : BaseEntity
{
    public Guid ReservationId { get; set; }

    public Guid? UserId { get; set; }
    
    [MaxLength(128)]
    public string GuestName { get; set; }
    
    public ParticipantStatus Status { get; set; } = ParticipantStatus.Invited;

    public decimal AmountToPay { get; set; }

    public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Unpaid;

    [MaxLength(512)]
    public string PaymentTransactionId { get; set; }

    [NotMapped]
    public string DisplayName => User?.FullName ?? GuestName ?? "Bilinmeyen Oyuncu";
    
    [ForeignKey("ReservationId")]
    public virtual Reservation Reservation { get; set; }
    
    [ForeignKey("UserId")]
    public virtual User User { get; set; }
}