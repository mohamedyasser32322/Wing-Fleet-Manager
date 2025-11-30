using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Repository.Interface
{
    public interface IFileRecordRepository
    {
        public Task<List<FileRecord>> GetAllAsync();
        public Task<FileRecord> GetByIdAsync(int id);
        public Task AddAsync(FileRecord fileRecord);
        public Task UpdateAsync(FileRecord fileRecord);
        public Task DeleteAsync(int id);
    }
}
