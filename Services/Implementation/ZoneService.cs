using AutoMapper;
using Wing_Fleet_Manager.Dtos.Zone;
using Wing_Fleet_Manager.Models;
using Wing_Fleet_Manager.Repository.Interface;
using Wing_Fleet_Manager.Services.Interface;

namespace Wing_Fleet_Manager.Services.Implementation
{
    public class ZoneService : IZoneService
    {
        private readonly IZoneRepository _zoneRepo;
        private readonly IMapper _mapper;
        public ZoneService(IZoneRepository zoneRepo,IMapper mapper)
        {
            _zoneRepo = zoneRepo;
            _mapper = mapper;
        }

        public async Task<List<ZoneReadDto>> GetAllAsync()
        {
            var Zones = await _zoneRepo.GetAllAsync();
            return _mapper.Map<List<ZoneReadDto>>(Zones);
        }

        public async Task<ZoneReadDto?> GetByIdAsync(int id)
        {
            var zone = await _zoneRepo.GetByIdAsync(id);
            if(zone == null)
            {
                throw new KeyNotFoundException($"Zone With Id #{id} Is Not Found");
            }
            else
            {
                return _mapper.Map<ZoneReadDto>(zone);
            }
        }

        public async Task<ZoneReadDto> AddAsync(ZoneCreateDto zoneCreateDto)
        {
            var existZone = await _zoneRepo.GetByNameAsync(zoneCreateDto.Name);
            if(existZone != null)
            {
                throw new InvalidOperationException("Zone Is Already Exists");
            }
            var zoneEntity = _mapper.Map<Zone>(zoneCreateDto);
            zoneEntity.CreatedAt = DateTime.Now;
            await _zoneRepo.AddAsync(zoneEntity);
            return _mapper.Map<ZoneReadDto>(zoneEntity);
        }

        public async Task<ZoneReadDto> UpdateAsync(ZoneUpdateDto zoneUpdateDto)
        {
            var zone = await _zoneRepo.GetByIdAsync(zoneUpdateDto.Id);
            if( zone == null )
            {
                throw new KeyNotFoundException($"Zone With Id #{zoneUpdateDto.Id} Not Exist");
            }
            var existZone = await _zoneRepo.GetByNameAsync(zoneUpdateDto.Name);
            if(existZone!= null && existZone.Id != zoneUpdateDto.Id)
            {
                throw new InvalidOperationException("Zone name already exists.");
            }

            _mapper.Map(zoneUpdateDto, zone);
            zone.LastUpdatedAt = DateTime.Now;
            await _zoneRepo.UpdateAsync(zone);
            return _mapper.Map<ZoneReadDto>(zone);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existZone = await _zoneRepo.GetByIdAsync(id);
            if(existZone == null)
            {
                throw new KeyNotFoundException($"Zone With Id #{id} Not Exist");
            }
            else
            {
                await _zoneRepo.DeleteAsync(id);
                existZone.LastUpdatedAt = DateTime.Now;
                return true;
            }
        }

        public async Task <int> GetZoneVehiclesCountAsync(int id)
        {
            var zone = await _zoneRepo.GetByIdAsync(id);
            if(zone == null)
            {
                throw new KeyNotFoundException($"Zone With Id #{id} Not Found");
            }

            return await _zoneRepo.GetVehiclesCountAsync(id);
        }
    }
}
