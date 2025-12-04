using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Repository.Interface
{
    public interface IVehicleRepository
    {
        public Task<List<Vehicle>> GetAllAsync();
        public Task<Vehicle> GetByIdAsync(int id);
        public Task<Vehicle> GetByQrAsync(string qr);
        public Task<int> CountAsync();
        public Task AddAsync(Vehicle vehicle);
        public Task UpdateAsync(Vehicle vehicle);
        public Task DeleteAsync(int id);
    }
}
