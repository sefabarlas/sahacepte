using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SahaCepteApp.Domain.Entities;

public class FacilityOwner : BaseEntity
{
    public Guid UserId { get; set; }
    
    [Required]
    [MaxLength(256)]
    public string CompanyName { get; set; }

    [MaxLength(64)]
    public string TaxNumber { get; set; }

    [MaxLength(64)]
    public string Iban { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; }
    
    public virtual ICollection<Facility> Facilities { get; set; }
}