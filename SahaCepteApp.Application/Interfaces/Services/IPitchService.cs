using SahaCepteApp.Domain.Dtos.Facility;
using SahaCepteApp.Domain.Wrappers;

namespace SahaCepteApp.Application.Interfaces.Services;

public interface IPitchService
{
    Task<ServiceResponse<List<TimeSlotDto>>> GetDailyAvailabilityAsync(Guid pitchId, DateTime date);
}