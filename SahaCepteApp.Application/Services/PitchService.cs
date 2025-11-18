using SahaCepteApp.Application.Interfaces.Persistence;
using SahaCepteApp.Application.Interfaces.Services;
using SahaCepteApp.Domain.Dtos.Facility;
using SahaCepteApp.Domain.Enums;
using SahaCepteApp.Domain.Wrappers;

namespace SahaCepteApp.Application.Services;

public class PitchService(IUnitOfWork unitOfWork) : IPitchService
{
    public async Task<ServiceResponse<List<TimeSlotDto>>> GetDailyAvailabilityAsync(Guid pitchId, DateTime date)
    {
        var pitch = await unitOfWork.Pitches.GetByIdAsync(pitchId);
        if (pitch == null) 
            return ServiceResponse<List<TimeSlotDto>>.NotFoundResult(null!);
        
        var reservations = await unitOfWork.Reservations.FindAsync(r =>
            r.PitchId == pitchId &&
            r.MatchDate.Date == date.Date &&
            r.Status != ReservationStatus.Cancelled);

        var slots = new List<TimeSlotDto>();
        
        var current = pitch.OpeningTime;
        var closing = pitch.ClosingTime;
        
        if (closing < current) 
            closing = new TimeSpan(23, 59, 0);

        while (current < closing)
        {
            var slotTimeStr = current.ToString(@"hh\:mm");
            var isBooked = reservations.Any(r => r.StartTime == current);

            var isPast = date.Date == DateTime.UtcNow.Date && current < DateTime.Now.TimeOfDay || date.Date < DateTime.UtcNow.Date;
            
            var status = "Available";
            if (isBooked)
                status = "Full";
            else if (isPast) 
                status = "Closed";

            slots.Add(new TimeSlotDto
            {
                Time = slotTimeStr,
                Status = status,
                Price = pitch.PricePerHour,
                IsPast = isPast
            });
            
            current = current.Add(TimeSpan.FromHours(1));
        }

        return ServiceResponse<List<TimeSlotDto>>.SuccessResult(slots);
    }
}