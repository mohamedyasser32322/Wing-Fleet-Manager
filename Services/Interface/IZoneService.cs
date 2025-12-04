using Wing_Fleet_Manager.Dtos.Zone;

namespace Wing_Fleet_Manager.Services.Interface
{
    public interface IZoneService
    {
        public Task<List<ZoneReadDto>> GetAllAsync();
        public Task<ZoneReadDto> GetByIdAsync(int id);
        public Task<IEnumerable<ZoneEnum>> GetZones();
        public Task<int> VehiclesCountByZoneId(int zoneId);
        public Task<int> CountAsync();
        public Task<ZoneReadDto> AddAsync(ZoneCreateDto zoneCreateDto);
        public Task<ZoneReadDto> UpdateAsync(ZoneUpdateDto zoneUpdateDto);
        public Task<bool> DeleteAsync(int id);
    }
}