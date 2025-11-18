namespace SahaCepteApp.Domain.Enums;

public enum PlayerPosition
{
    Goalkeeper = 1,
    Defender = 2,
    Midfielder = 3,
    Forward = 4
}

public enum StrongFoot
{
    Right = 1,
    Left = 2,
    Both = 3
}

public enum PitchType
{
    Indoor = 1,  // Kapalı Saha
    Outdoor = 2  // Açık Saha
}

public enum PitchStatus
{
    Available = 1,  // Kapalı Saha
    InCare = 2  // Bakımda
}

public enum SurfaceType
{
    ArtificialTurf = 1, // Suni Çim
    NaturalGrass = 2,   // Doğal Çim
    Hybrid = 3,         // Hibrit
    Parquet = 4         // Parke (Kapalı spor salonu)
}

public enum ReservationStatus
{
    Pending = 1,     // Beklemede (Ödeme bekleniyor olabilir)
    Confirmed = 2,   // Onaylandı (Kesin kayıt)
    Completed = 3,   // Maç bitti
    Cancelled = 4,   // İptal edildi
    NoShow = 5       // Maça gelmediler (Kara liste için)
}

public enum PaymentType
{
    AtVenue = 1,     // Sahada Ödeme
    CreditCard = 2,  // Kredi Kartı (Tamamı)
    SplitPayment = 3 // Alman Usulü (Herkes ayrı öder)
}

public enum ParticipantStatus
{
    Invited = 1,     // Davet gönderildi
    Accepted = 2,    // Kabul etti (Geliyor)
    Rejected = 3,    // Reddetti
    Organizer = 4    // Maçı kuran kişi
}
    
public enum PaymentStatus
{
    Unpaid = 1,      // Ödenmedi
    Paid = 2,        // Ödendi
    Refunded = 3     // İade Edildi
}