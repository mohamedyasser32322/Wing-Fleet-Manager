using Microsoft.EntityFrameworkCore;
using Wing_Fleet_Manager.Data;
using Wing_Fleet_Manager.Models;
using Wing_Fleet_Manager.Repository.Interface;

namespace Wing_Fleet_Manager.Repository.Implmentation
{
    public class FileRecordRepository : IFileRecordRepository
    {
        private readonly WingDbContext _context;
        public FileRecordRepository(WingDbContext context)
        {
            _context = context;
        }

        public async Task<List<FileRecord>> GetAllAsync()
        {
            return await _context.FileRecords.ToListAsync();
        }

        public async Task<FileRecord?> GetByIdAsync(int id)
        {
            return await _context.FileRecords.FirstOrDefaultAsync(fr => fr.Id == id);
        }

        public async Task AddAsync(FileRecord fileRecord)
        {
            await _context.FileRecords.AddAsync(fileRecord);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FileRecord fileRecord)
        {
            _context.FileRecords.Update(fileRecord);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var FileRecord = await _context.FileRecords.FindAsync(id);
            if (FileRecord != null)
            {
                _context.FileRecords.Remove(FileRecord);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"File With Id #{id} Is Not Found");
            }
        }
    }
}
