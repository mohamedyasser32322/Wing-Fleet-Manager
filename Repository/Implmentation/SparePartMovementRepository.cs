using Microsoft.EntityFrameworkCore;
using Wing_Fleet_Manager.Data;
using Wing_Fleet_Manager.Models;
using Wing_Fleet_Manager.Repository.Interface;

namespace Wing_Fleet_Manager.Repository.Implmentation
{
    public class SparePartMovementRepository : ISparePartMovementRepository
    {
        private readonly WingDbContext _context;
        public SparePartMovementRepository(WingDbContext context)
        {
            _context = context;
        }

        public async Task<List<SparePartMovement>> GetAllAsync()
        {
            return await _context.SparePartMovements.ToListAsync();
        }

        public async Task<SparePartMovement?> GetByIdAsync(int id)
        {
            return await _context.SparePartMovements.FirstOrDefaultAsync(spm => spm.Id == id);
        }

        public async Task AddAsync(SparePartMovement sparePartMovement)
        {
            await _context.SparePartMovements.AddAsync(sparePartMovement);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SparePartMovement sparePartMovement)
        {
            _context.SparePartMovements.Update(sparePartMovement);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var SparePartMovement = await _context.SparePartMovements.FindAsync(id);
            if (SparePartMovement != null)
            {
                _context.SparePartMovements.Remove(SparePartMovement);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Movement With Id #{id} Is Not Found");
            }
        }
    }
}
