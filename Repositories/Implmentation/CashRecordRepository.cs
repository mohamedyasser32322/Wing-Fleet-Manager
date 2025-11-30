using Microsoft.EntityFrameworkCore;
using Wing_Fleet_Manager.Data;
using Wing_Fleet_Manager.Models;
using Wing_Fleet_Manager.Repository.Interface;

namespace Wing_Fleet_Manager.Repository.Implmentation
{
    public class CashRecordRepository : ICashRecordRepository
    {
        private readonly WingDbContext _context;
        public CashRecordRepository(WingDbContext context)
        {
            _context = context;
        }

        public async Task<List<CashRecord>> GetAllAsync()
        {
            return await _context.CashRecords.ToListAsync();
        }

        public async Task<CashRecord?> GetByIdAsync(int id)
        {
            return await _context.CashRecords.FirstOrDefaultAsync(cr => cr.Id == id);
        }

        public async Task AddAsync(CashRecord cashRecord)
        {
            await _context.CashRecords.AddAsync(cashRecord);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CashRecord cashRecord)
        {
            _context.CashRecords.Update(cashRecord);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var CashRecord = await _context.CashRecords.FindAsync(id);
            if (CashRecord != null)
            {
                _context.CashRecords.Remove(CashRecord);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Cash Record With Id #{id} Is Not Found");
            }
        }
    }
}
