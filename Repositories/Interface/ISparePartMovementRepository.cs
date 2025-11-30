using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Repository.Interface
{
    public interface ISparePartMovementRepository
    {
        public Task<List<SparePartMovement>> GetAllAsync();
        public Task<SparePartMovement> GetByIdAsync(int id);
        public Task AddAsync(SparePartMovement sparePartMovement);
        public Task UpdateAsync(SparePartMovement sparePartMovement);
        public Task DeleteAsync(int id);
    }
}
