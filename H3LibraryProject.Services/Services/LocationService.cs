using H3LibraryProject.API.DTOs;
using H3LibraryProject.Repositories.Database;
using H3LibraryProject.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3LibraryProject.Services.Services
{
    public interface ILocationService
    {
        Task<List<LocationResponse>> GetAllLocations();
        Task<LocationResponse> GetLocationById(int id);
        Task<LocationResponse> CreateLocation(LocationRequest request);
        Task<LocationResponse> UpdateLocation(int id, LocationRequest request);
        Task<LocationResponse> DeleteLocation(int id);
    }

    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _repository;

        public LocationService(ILocationRepository repository)
        {
            _repository = repository;
        }
        public async Task<LocationResponse> CreateLocation(LocationRequest request)
        {
            Location newLocation = MapLocationRequestToLocation(request);
            newLocation = await _repository.CreateLocation(newLocation);

            if (newLocation != null)
            {
                return MapLocationToLocationResponse(newLocation);

            }
            return null;
        }

        public async Task<LocationResponse> DeleteLocation(int id)
        {
            Location deletedLocation = await _repository.DeleteLocation(id);
            if (deletedLocation != null)
            {
                return MapLocationToLocationResponse(deletedLocation);
            }
            return null;
        }

        public async Task<List<LocationResponse>> GetAllLocations()
        {
            List<Location> locations = await _repository.GetAllLocations();
            return locations.Select(location => MapLocationToLocationResponse(location)).ToList();
        }

        public async Task<LocationResponse> GetLocationById(int id)
        {
            Location location = await _repository.GetLocationById(id);
            if (location != null)
            {
                return MapLocationToLocationResponse(location);
            }
            return null;
        }

        public async Task<LocationResponse> UpdateLocation(int id, LocationRequest request)
        {
            Location updateLocation = MapLocationRequestToLocation(request);
            updateLocation = await _repository.UpdateLocation(id, updateLocation);

            if (updateLocation != null)
            {
                return MapLocationToLocationResponse(updateLocation);
            }
            return null;
        }

        private Location MapLocationRequestToLocation(LocationRequest request)
        {
            return new()
            {
                Name = request.Name
            };
        }

        private LocationResponse MapLocationToLocationResponse(Location location)
        {

            return new()
            {
                LocationId = location.LocationId,
                Name = location.Name
            };

        }
    }
}
