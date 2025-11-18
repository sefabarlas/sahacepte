using SahaCepteApp.Domain.Dtos.Facility;
using SahaCepteApp.Domain.Wrappers;

namespace SahaCepteApp.Application.Interfaces.Services;

public interface IReservationService
{
    Task<ServiceResponse<Guid>> CreateReservationAsync(CreateReservationDto dto);
}