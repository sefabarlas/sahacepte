using System.Text.Json;
using SahaCepteApp.Application.Interfaces.Persistence;
using SahaCepteApp.Application.Interfaces.Services;
using SahaCepteApp.Domain.Dtos.Facility;
using SahaCepteApp.Domain.Wrappers;

namespace SahaCepteApp.Application.Services;

public class FacilityService(IUnitOfWork unitOfWork) : IFacilityService
{
    public async Task<ServiceResponse<IEnumerable<FacilityListDto>>> GetAllFacilitiesAsync(FacilityFilterDto filter)
    {
        var facilities = await unitOfWork.Facilities.GetAllAsync();
        
        var facilityListDtos = facilities.Select(v => 
        {
            List<string>? images = null;
            try 
            {
                if (!string.IsNullOrEmpty(v.ImageUrls))
                    images = JsonSerializer.Deserialize<List<string>>(v.ImageUrls);
            }
            catch
            {
                // ignored
            }

            return new FacilityListDto
            {
                Id = v.Id,
                Name = v.Name,
                CityName = v.CityId == 16 ? "Bursa" : "Diğer",
                DistrictName = "Merkez",
                ImageUrl = images?.FirstOrDefault() ?? "", 
                MinPrice = 0,
                Rating = 0
            };
        }).ToList();

        return ServiceResponse<IEnumerable<FacilityListDto>>.SuccessResult(facilityListDtos);
    }

    public async Task<ServiceResponse<FacilityDto?>> GetFacilityDetailAsync(Guid id)
    {
        var venue = await unitOfWork.Facilities.GetFacilityWithPitchesAsync(id);

        if (venue == null) 
            return ServiceResponse<FacilityDto?>.NotFoundResult(null);
        
        List<string> amenities = [];
        List<string> images = [];

        try
        {
            if (!string.IsNullOrEmpty(venue.Amenities))
                amenities = JsonSerializer.Deserialize<List<string>>(venue.Amenities) ?? [];

            if (!string.IsNullOrEmpty(venue.ImageUrls))
                images = JsonSerializer.Deserialize<List<string>>(venue.ImageUrls) ?? [];
        }
        catch
        {
            // ignored
        }

        return ServiceResponse<FacilityDto?>.SuccessResult(new FacilityDto
        {
            Id = venue.Id,
            Name = venue.Name,
            Description = venue.Description,
            Address = venue.Address,
            PhoneNumber = venue.PhoneNumber,
            Latitude = venue.Latitude,
            Longitude = venue.Longitude,
            Amenities = amenities,
            ImageUrls = images,
            Pitches = venue.Pitches.Select(p => new FacilityDetailPitchDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.PricePerHour,
                Type = p.Type.ToString()
            }).ToList()
        });
    }
}