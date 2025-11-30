using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Repository.Interface
{
    public interface IFaultRepository
    {
        public Task<List<Fault>> GetAllAsync();
        public Task<Fault> GetByIdAsync(int id);
        public Task AddAsync(Fault fault);
        public Task UpdateAsync(Fault fault);
        public Task DeleteAsync(int id);
    }
}
