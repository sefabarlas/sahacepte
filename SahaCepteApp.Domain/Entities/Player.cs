using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SahaCepteApp.Domain.Enums;

namespace SahaCepteApp.Domain.Entities;

public class Player : BaseEntity
{
    public Guid UserId { get; set; }
    
    [MaxLength(128)]
    public string Nickname { get; set; }

    public PlayerPosition Position { get; set; } = PlayerPosition.Midfielder;

    public StrongFoot StrongFoot { get; set; } = StrongFoot.Right;

    public int? JerseyNumber { get; set; }

    [Range(100, 250)]
    public int? Height { get; set; } // cm

    [Range(30, 150)]
    public int? Weight { get; set; } // kg
    
    public decimal AverageRating { get; set; }
    
    public int MatchesPlayed { get; set; }

    [MaxLength(512)]
    public string Bio { get; set; }
    
    [ForeignKey("UserId")]
    public virtual User User { get; set; }
}