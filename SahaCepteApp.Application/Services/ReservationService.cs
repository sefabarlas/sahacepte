using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SahaCepteApp.Application.Interfaces.Persistence;
using SahaCepteApp.Application.Interfaces.Services;
using SahaCepteApp.Domain.Dtos.Facility;
using SahaCepteApp.Domain.Entities;
using SahaCepteApp.Domain.Enums;
using SahaCepteApp.Domain.Wrappers;

namespace SahaCepteApp.Application.Services;

public class ReservationService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContext) : IReservationService
{
    public async Task<ServiceResponse<Guid>> CreateReservationAsync(CreateReservationDto dto)
    {
        // var userId = httpContext.HttpContext.User.GetUserId();
        if (dto.MatchDate.Date < DateTime.UtcNow.Date)
            return ServiceResponse<Guid>.FailureResult("Geçmiş tarihe rezervasyon yapılamaz." );

        var pitch = await unitOfWork.Pitches.GetByIdAsync(dto.PitchId);
        if (pitch == null)
            return ServiceResponse<Guid>.FailureResult("Saha bulunamadı." );
        
        var reservation = new Reservation
        {
            Id = Guid.NewGuid(),
            PitchId = dto.PitchId,
            OrganizerId = dto.UserId,
            MatchDate = dto.MatchDate.Date,
            StartTime = dto.StartTime,
            EndTime = dto.StartTime.Add(TimeSpan.FromHours(1)),
            TotalPrice = pitch.PricePerHour,
            Status = ReservationStatus.Pending,
            Note = dto.Note,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = dto.UserId,
            IsActive = true
        };

        reservation.Participants.Add(new ReservationParticipant
        {
            Id = Guid.NewGuid(),
            UserId = dto.UserId,
            Status = ParticipantStatus.Organizer,
            AmountToPay = pitch.PricePerHour,
            PaymentStatus = PaymentStatus.Unpaid
        });

        try
        {
            await unitOfWork.Reservations.AddAsync(reservation);
            await unitOfWork.SaveChangesAsync();

            return ServiceResponse<Guid>.SuccessResult(reservation.Id);
        }
        catch (DbUpdateException ex)
        {
            // Eğer hata PostgreSQL'in Unique Constraint hatasıysa (23505)
            // Bu demektir ki; tam biz kaydederken başkası o saati kaptı.
            if (ex.InnerException != null && ex.InnerException.Message.Contains("23505"))
            {
                return ServiceResponse<Guid>.FailureResult("Üzgünüz! Bu saat saniyeler farkla doldu.");
            }

            throw;
        }
    }
}