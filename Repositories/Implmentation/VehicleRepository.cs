using Microsoft.EntityFrameworkCore;
using Wing_Fleet_Manager.Data;
using Wing_Fleet_Manager.Models;
using Wing_Fleet_Manager.Repository.Interface;

namespace Wing_Fleet_Manager.Repository.Implmentation
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly WingDbContext _context;
        public VehicleRepository(WingDbContext context)
        {
            _context = context;
        }

        public async Task<List<Vehicle>> GetAllAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<Vehicle?> GetByIdAsync(int id)
        {
            return await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<Vehicle?> GetByQrAsync(string qr)
        {
            return await _context.Vehicles
                .FirstOrDefaultAsync(v => v.Qr == qr);
        }

        public async Task AddAsync(Vehicle vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Vehicle vehicle)
        {
            _context.Vehicles.Update(vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle != null)
            {
                vehicle.IsDeleted = true;
                vehicle.LastUpdatedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Vehicle With Id #{id} Not Found");
            }
        }
    }
}
