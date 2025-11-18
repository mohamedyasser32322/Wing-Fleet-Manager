using Wing_Fleet_Manager.Dtos.Zone;

namespace Wing_Fleet_Manager.Services.Interface
{
    public interface IZoneService
    {
        public Task<List<ZoneReadDto>> GetAllAsync();
        public Task<ZoneReadDto> GetByIdAsync(int id);
        public Task<ZoneReadDto> AddAsync(ZoneCreateDto zoneCreateDto);
        public Task<ZoneReadDto> UpdateAsync(ZoneUpdateDto zoneUpdateDto);
        public Task<bool> DeleteAsync(int id);
        public Task<int> GetZoneVehiclesCountAsync(int id);
    }
}