using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SahaCepteApp.Domain.Entities;
using SahaCepteApp.Domain.Enums;

namespace SahaCepte.Infrastructure.Persistence.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Facility> Facilities { get; set; }
    public DbSet<FacilityOwner> FacilityOwners { get; set; }
    public DbSet<Pitch> Pitches { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<ReservationParticipant> ReservationParticipants { get; set; }
    public DbSet<User> Users { get; set; }
    
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<decimal>()
            .HavePrecision(10, 2);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Facility>()
            .HasOne(f => f.FacilityOwner)
            .WithMany(fo => fo.Facilities) 
            .HasForeignKey(f => f.OwnerId); 

        modelBuilder.Entity<FacilityOwner>()
            .HasOne(fo => fo.User)
            .WithOne(u => u.FacilityOwner)
            .HasForeignKey<FacilityOwner>(fo => fo.UserId);
        
        modelBuilder.Entity<Pitch>()
            .HasOne(p => p.Facility)
            .WithMany(f => f.Pitches)
            .HasForeignKey(p => p.FacilityId); 
        
        modelBuilder.Entity<Player>()
            .HasOne(p => p.User)
            .WithOne(u => u.Player)
            .HasForeignKey<Player>(p => p.UserId);

        // 1. Double Booking Koruması (Unique Index)
        // Aynı Saha + Aynı Tarih + Aynı Başlangıç Saati = SADECE 1 KAYIT OLABİLİR.
        // Şart: İptal edilmemiş kayıtlar arasında (Status != Cancelled)
        modelBuilder.Entity<Reservation>()
            .HasIndex(r => new { r.PitchId, r.MatchDate, r.StartTime })
            .IsUnique()
            .HasFilter($"\"Status\" != {(int)ReservationStatus.Cancelled}"); 

        modelBuilder.Entity<Reservation>()
            .HasMany(r => r.Participants)
            .WithOne(p => p.Reservation)
            .HasForeignKey(p => p.ReservationId); 

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reservations)
            .HasForeignKey(r => r.OrganizerId);
        
        modelBuilder.Entity<User>()
            .HasIndex(u => u.PhoneNumber)
            .IsUnique();
        
        var entities = modelBuilder.Model.GetEntityTypes()
            .Where(t => typeof(BaseEntity).IsAssignableFrom(t.ClrType));

        foreach (var entity in entities)
        {
            var method = typeof(AppDbContext)
                .GetMethod(nameof(SetGlobalQueryFilter), BindingFlags.NonPublic | BindingFlags.Instance)
                ?.MakeGenericMethod(entity.ClrType);

            method?.Invoke(this, [modelBuilder]);
        }
        
        base.OnModelCreating(modelBuilder);
    }
    
    private static void SetGlobalQueryFilter<T>(ModelBuilder modelBuilder) where T : BaseEntity
    {
        modelBuilder.Entity<T>().HasQueryFilter(e => e.IsActive && e.DeletedAt == null);
    }
}