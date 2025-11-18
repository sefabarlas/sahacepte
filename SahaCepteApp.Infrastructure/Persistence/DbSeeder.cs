using Microsoft.EntityFrameworkCore;
using SahaCepte.Infrastructure.Persistence.Context;
using SahaCepteApp.Domain.Entities;
using SahaCepteApp.Domain.Enums;

namespace SahaCepte.Infrastructure.Persistence;

public static class DbSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if (await context.Facilities.AnyAsync()) return;

            var playerUser = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Sefa",
                LastName = "Barlas",
                PhoneNumber = "5071813281",
                AvatarUrl = "https://i.pravatar.cc/150?img=11",
                CreatedAt = DateTime.UtcNow
            };

            var playerProfile = new Player
            {
                Id = Guid.NewGuid(),
                UserId = playerUser.Id,
                Position = PlayerPosition.Forward,
                StrongFoot = StrongFoot.Right,
                Nickname = "Dede",
                JerseyNumber = 9
            };

            var ownerUser = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Ahmet",
                LastName = "İşletmeci",
                PhoneNumber = "5559998877",
                CreatedAt = DateTime.UtcNow
            };

            var ownerProfile = new FacilityOwner
            {
                Id = Guid.NewGuid(),
                UserId = ownerUser.Id,
                CompanyName = "Esas Spor Tesisleri",
                TaxNumber = "1234567890"
            };

            var facility = new Facility
            {
                Id = Guid.NewGuid(),
                OwnerId = ownerProfile.Id,
                Name = "Esas Spor Tesisleri",
                Description = "Bursa'nın en modern tesisleri. Duş, kafeterya ve otopark mevcuttur.",
                PhoneNumber = "02243334455",
                CityId = 16,
                DistrictId = 1,
                Address = "Konak, 16110 Ni̇lüfer/Bursa",
                Latitude = 40.1932,
                Longitude = 29.2254,
                Amenities = "[\"wifi\", \"parking\", \"shower\", \"cafe\"]",
                ImageUrls = "[\"https://picsum.photos/id/1/800/600\", \"https://picsum.photos/id/2/800/600\"]"
            };

            var pitch1 = new Pitch
            {
                Id = Guid.NewGuid(),
                FacilityId = facility.Id,
                Name = "A Sahası (Açık)",
                Type = PitchType.Outdoor,
                Surface = SurfaceType.ArtificialTurf,
                Width = 30,
                Length = 50,
                Capacity = 14,
                PricePerHour = 2520,
                OpeningTime = new TimeSpan(9, 0, 0),
                ClosingTime = new TimeSpan(3, 0, 0)
            };
            
            await context.Users.AddRangeAsync(playerUser, ownerUser);
            await context.Players.AddAsync(playerProfile);
            await context.FacilityOwners.AddAsync(ownerProfile);
            await context.Facilities.AddAsync(facility);
            await context.Pitches.AddAsync(pitch1);

            await context.SaveChangesAsync();
        }
    }