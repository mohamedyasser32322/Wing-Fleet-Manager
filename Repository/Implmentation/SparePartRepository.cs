using Microsoft.EntityFrameworkCore;
using Wing_Fleet_Manager.Data;
using Wing_Fleet_Manager.Models;
using Wing_Fleet_Manager.Repository.Interface;

namespace Wing_Fleet_Manager.Repository.Implmentation
{
    public class SparePartRepository : ISparePartRepository
    {
        private readonly WingDbContext _context;
        public SparePartRepository(WingDbContext context)
        {
            _context = context;
        }

        public async Task<List<SparePart>> GetAllAsync()
        {
            return await _context.SpareParts.ToListAsync();
        }

        public async Task<SparePart?> GetByIdAsync(int id)
        {
            return await _context.SpareParts.FirstOrDefaultAsync(sp => sp.Id == id);
        }

        public async Task AddAsync(SparePart sparePart)
        {
            await _context.SpareParts.AddAsync(sparePart);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SparePart sparePart)
        {
            _context.SpareParts.Update(sparePart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var SparePart = await _context.SpareParts.FindAsync(id);
            if (SparePart != null)
            {
                _context.SpareParts.Remove(SparePart);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Spare Part With Id #{id} Is Not Found");
            }
        }
    }
}
