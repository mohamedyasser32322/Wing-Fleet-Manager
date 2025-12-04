using Wing_Fleet_Manager.Dtos.Vehicle;

namespace Wing_Fleet_Manager.Services.Interface
{
    public interface IVehicleService
    {
        Task<List<VehicleReadDto>> GetAllAsync();
        Task<VehicleReadDto> GetByIdAsync(int id);
        Task<VehicleReadDto> GetByQrAsync(string qr);
        Task<int> CountAsync();
        Task<VehicleReadDto> AddAsync(VehicleCreateDto vehicleCreateDto);
        Task<VehicleReadDto> UpdateAsync(VehicleUpdateDto vehicleUpdateDto);
        Task<bool> DeleteAsync(int id);
    }
}
