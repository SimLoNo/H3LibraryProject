using H3LibraryProject.Repositories.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3LibraryProject.Repositories.Repositories
{
    public interface ILocationRepository
    {
        Task<List<Location>> GetAllLocations();
        Task<Location> GetLocationById(int id);
        Task<List<Location>> GetLocationByName(string locationName);
        Task<Location> CreateLocation(Location location);
        Task<Location> UpdateLocation(int id, Location location);
        Task<Location> DeleteLocation(int id);
    }
    public class LocationRepository : ILocationRepository
    {
        private readonly LibraryContext _context;

        public LocationRepository(LibraryContext context)
        {
            _context = context;
        }
        public async Task<Location> CreateLocation(Location location)
        {
            _context.Location.Add(location);
            await _context.SaveChangesAsync();
            return location;
        }

        public async Task<Location> DeleteLocation(int id)
        {
            Location deletedLocation = await _context.Location.FirstOrDefaultAsync(locationObj => locationObj.LocationId == id);
            if (deletedLocation != null)
            {
                _context.Location.Remove(deletedLocation);
                await _context.SaveChangesAsync();
            }
            return deletedLocation;
        }

        public async Task<List<Location>> GetAllLocations()
        {
            return await _context.Location.ToListAsync();
        }

        public async Task<Location> GetLocationById(int id)
        {
            return await _context.Location.FirstOrDefaultAsync(location => location.LocationId == id);

        }

        public async Task<List<Location>> GetLocationByName(string locationName)
        {
            return await _context.Location.Where(locationObj => locationObj.Name.Contains(locationName)).ToListAsync();
        }

        public async Task<Location> UpdateLocation(int id, Location location)
        {
            Location updatedLocation = await _context.Location.FirstOrDefaultAsync(locationObj => locationObj.LocationId == id);
            if (updatedLocation != null)
            {
                updatedLocation.Name = location.Name;
                await _context.SaveChangesAsync();
            }
            return updatedLocation;
        }
    }
}
