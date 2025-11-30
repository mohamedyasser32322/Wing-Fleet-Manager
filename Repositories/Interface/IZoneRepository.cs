using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Repository.Interface
{
    public interface IZoneRepository
    {
        public Task<List<Zone>> GetAllAsync();
        public Task<Zone?> GetByIdAsync(int id);
        public Task<Zone?> GetByNameAsync(string name);
        public Task AddAsync(Zone zone);
        public Task UpdateAsync(Zone zone);
        public Task DeleteAsync(int id);
        public Task<int> GetVehiclesCountAsync(int zoneId);
    }
}
