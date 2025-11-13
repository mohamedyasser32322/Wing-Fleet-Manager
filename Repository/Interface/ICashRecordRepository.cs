using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Repository.Interface
{
    public interface ICashRecordRepository
    {
        public Task<List<CashRecord>> GetAllAsync();
        public Task<CashRecord> GetByIdAsync(int id);
        public Task AddAsync(CashRecord cashRecord);
        public Task UpdateAsync(CashRecord cashRecord);
        public Task DeleteAsync(int id);
    }
}
