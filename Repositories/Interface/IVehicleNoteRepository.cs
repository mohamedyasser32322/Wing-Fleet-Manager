using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Repository.Interface
{
    public interface IVehicleNoteRepository
    {
        public Task<List<VehicleNote>> GetAllAsync();
        public Task<VehicleNote> GetByIdAsync(int id);
        public Task AddAsync(VehicleNote vehicleNote);
        public Task UpdateAsync(VehicleNote vehicleNote);
        public Task DeleteAsync(int id);
    }
}
