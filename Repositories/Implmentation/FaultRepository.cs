using Microsoft.EntityFrameworkCore;
using Wing_Fleet_Manager.Data;
using Wing_Fleet_Manager.Models;
using Wing_Fleet_Manager.Repository.Interface;

namespace Wing_Fleet_Manager.Repository.Implmentation
{
    public class FaultRepository : IFaultRepository
    {
        private readonly WingDbContext _context;
        public FaultRepository(WingDbContext context)
        {
            _context = context;
        }

        public async Task<List<Fault>> GetAllAsync()
        {
            return await _context.Faults
                .Include(f => f.Vehicle)
                .Where(f => !f.IsDeleted)
                .ToListAsync();
                
        }

        public async Task<Fault?> GetByIdAsync(int id)
        {
            return await _context.Faults.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<int> GetLastSerialAsync()
        {
            return await _context.Faults
                .OrderByDescending(f => f.SerialNumber)
                .Select(f => f.SerialNumber)
                .FirstOrDefaultAsync();
        }
        public async Task<int> CountAsync()
        {
            return await _context.Faults
                .Where(f => !f.IsDeleted)
                .CountAsync();
        }

        public async Task AddAsync(Fault fault)
        {
            await _context.Faults.AddAsync(fault);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Fault fault)
        {
            _context.Faults.Update(fault);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Fault = await _context.Faults.FindAsync(id);
            if (Fault != null)
            {
                Fault.IsDeleted = true;
                Fault.SolvedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Fault With Id #{id} Is Not Found");
            }
        }
    }
}
