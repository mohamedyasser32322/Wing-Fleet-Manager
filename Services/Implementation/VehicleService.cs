using AutoMapper;
using Wing_Fleet_Manager.Dtos.Vehicle;
using Wing_Fleet_Manager.Dtos.Zone;
using Wing_Fleet_Manager.Models;
using Wing_Fleet_Manager.Repository.Interface;
using Wing_Fleet_Manager.Services.Interface;

namespace Wing_Fleet_Manager.Services.Implementation
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;
        public VehicleService(IVehicleRepository vehicleRepository,IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<List<VehicleReadDto>> GetAllAsync()
        {
            var vehicles = await _vehicleRepository.GetAllAsync();
            return _mapper.Map<List<VehicleReadDto>>(vehicles);
        }

        public async Task<VehicleReadDto> GetByIdAsync(int id)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(id);
            if(vehicle == null)
            {
                throw new KeyNotFoundException($"Vehicle With Id #{id} Not Exist");
            }

            return _mapper.Map<VehicleReadDto>(vehicle);
        }

        public async Task<VehicleReadDto> GetByQrAsync(string qr)
        {
            var vehicle = await _vehicleRepository.GetByQrAsync(qr);
            if( vehicle == null)
            {
                throw new InvalidOperationException($"Vehicle With Qr #{qr} Not Exist");
            }

            return _mapper.Map<VehicleReadDto>(vehicle);
        }

        public async Task<int> CountAsync()
        {
           return await _vehicleRepository.CountAsync();
        }



        public async Task<VehicleReadDto> AddAsync(VehicleCreateDto vehicleCreateDto)
        {
            var existVehicle = await _vehicleRepository.GetByQrAsync(vehicleCreateDto.Qr);
            if( existVehicle != null)
            {
                throw new InvalidOperationException($"Vehicle With Qr #{vehicleCreateDto.Qr} Is Already Created");
            }
            var newVehicle = _mapper.Map<Vehicle>(vehicleCreateDto);
            newVehicle.CreatedAt = DateTime.Now;
            await _vehicleRepository.AddAsync(newVehicle);
            return _mapper.Map<VehicleReadDto>(newVehicle);
        }

        public async Task<VehicleReadDto> UpdateAsync(VehicleUpdateDto vehicleUpdateDto)
        {
            var existVehicle = await _vehicleRepository.GetByIdAsync(vehicleUpdateDto.Id);
            if (existVehicle == null)
            {
                throw new KeyNotFoundException($"Vehicle With Id #{vehicleUpdateDto.Id} Not Exist");
            }

            var existVehicleQr = await _vehicleRepository.GetByQrAsync(vehicleUpdateDto.Qr);
            if (existVehicleQr != null && existVehicleQr.Id != vehicleUpdateDto.Id)
            {
                throw new InvalidOperationException("Vehicle Qr already exists.");
            }
            _mapper.Map(vehicleUpdateDto, existVehicle);
            existVehicle.LastUpdatedAt = DateTime.Now;
            await _vehicleRepository.UpdateAsync(existVehicle);
            return _mapper.Map<VehicleReadDto>(existVehicle);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existVehicle = await _vehicleRepository.GetByIdAsync(id);
            if(existVehicle == null)
            {
                throw new KeyNotFoundException($"Vehicle With Id #{id} Not Exist");
            }
            else
            {
                await _vehicleRepository.DeleteAsync(id);
                existVehicle.LastUpdatedAt = DateTime.Now;
                return true;
            }
        }

    }
}
