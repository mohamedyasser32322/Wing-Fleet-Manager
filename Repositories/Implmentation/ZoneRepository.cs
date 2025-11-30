using Microsoft.EntityFrameworkCore;
using Wing_Fleet_Manager.Data;
using Wing_Fleet_Manager.Models;
using Wing_Fleet_Manager.Repository.Interface;

namespace Wing_Fleet_Manager.Repository.Implmentation
{
    public class ZoneRepository : IZoneRepository
    {
        private readonly WingDbContext _context;
        public ZoneRepository(WingDbContext context)
        {
            _context = context;
        }

        public async Task<List<Zone>> GetAllAsync()
        {
            return await _context.Zones.ToListAsync();
        } 

        public async Task<Zone?> GetByIdAsync(int id)
        {
            return await _context.Zones.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Zone?> GetByNameAsync(string name)
        {
            return await _context.Zones.FirstOrDefaultAsync(z => z.Name.ToLower() == name.ToLower());
        }

        public async Task AddAsync(Zone zone)
        {
            await _context.Zones.AddAsync(zone);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Zone zone)
        {
            _context.Zones.Update(zone);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var zone = await _context.Zones.FindAsync(id);
            if (zone != null)
            {
                zone.IsDeleted = true;
                zone.LastUpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
            else { 
                throw new KeyNotFoundException($"Zone With Id #{id} Not Found");
            }
        }

        public async Task<int> GetVehiclesCountAsync(int zoneId)
        {
            return await _context.Vehicles
                .Where(v => v.ZoneId ==  zoneId)
                .CountAsync();
        }
    }
}
