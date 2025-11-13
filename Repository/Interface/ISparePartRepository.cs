using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Repository.Interface
{
    public interface ISparePartRepository
    {
        public Task<List<SparePart>> GetAllAsync();
        public Task<SparePart> GetByIdAsync(int id);
        public Task AddAsync(SparePart sparePart);
        public Task UpdateAsync(SparePart sparePart);
        public Task DeleteAsync(int id);
    }
}
