using Microsoft.EntityFrameworkCore;
using Wing_Fleet_Manager.Data;
using Wing_Fleet_Manager.Models;
using Wing_Fleet_Manager.Repository.Interface;

namespace Wing_Fleet_Manager.Repository.Implmentation
{
    public class VehicleNoteRepository: IVehicleNoteRepository
    {
        private readonly WingDbContext _context;
        public VehicleNoteRepository(WingDbContext context)
        {
            _context = context;
        }

        public async Task<List<VehicleNote>> GetAllAsync()
        {
            return await _context.VehicleNotes.ToListAsync();
        }

        public async Task<VehicleNote?> GetByIdAsync(int id)
        {
            return await _context.VehicleNotes.FirstOrDefaultAsync(vn => vn.Id == id);
        }

        public async Task AddAsync(VehicleNote vehicleNote)
        {
            await _context.VehicleNotes.AddAsync(vehicleNote);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(VehicleNote vehicleNote)
        {
            _context.VehicleNotes.Update(vehicleNote);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var VehicleNote = await _context.VehicleNotes.FindAsync(id);
            if (VehicleNote != null)
            {
                _context.VehicleNotes.Remove(VehicleNote);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Note With Id #{id} Is Not Found");
            }
        }
    }
}
