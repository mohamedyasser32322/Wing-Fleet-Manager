using AutoMapper;
using Wing_Fleet_Manager.Dtos.Fault;
using Wing_Fleet_Manager.Dtos.Zone;
using Wing_Fleet_Manager.Models;
using Wing_Fleet_Manager.Repository.Interface;
using Wing_Fleet_Manager.Services.Interface;

namespace Wing_Fleet_Manager.Services.Implementation
{
    public class FaultService : IFaultService
    {
        private readonly IFaultRepository _faultRepository;
        private readonly IMapper _mapper;
        public FaultService(IFaultRepository faultRepository,IMapper mapper)
        {
            _faultRepository = faultRepository;
            _mapper = mapper;
        }

        public async Task<List<FaultReadDto>> GetAllAsync()
        {
            var faults = await _faultRepository.GetAllAsync();
            return _mapper.Map<List<FaultReadDto>>(faults);
        }

        public async Task<FaultReadDto> GetByIdAsunc(int id)
        {
            var fault = await _faultRepository.GetByIdAsync(id);
            if (fault != null)
            {
                return _mapper.Map<FaultReadDto>(fault);
            }
            else
            {
                throw new KeyNotFoundException($"Fault With Id #{id} Is Not Found");
            }
        }

        public async Task<int> CountAsync()
        {
            return await _faultRepository.CountAsync();
        }

        public async Task<FaultReadDto>AddAsync(FaultCreateDto faultCreateDto)
        {
            var fault = _mapper.Map<Fault>(faultCreateDto);
            fault.CreatedAt = DateTime.Now;

            int lastSerial = await _faultRepository.GetLastSerialAsync();
            fault.SerialNumber = lastSerial + 1;
            
            await _faultRepository.AddAsync(fault);
            return _mapper.Map<FaultReadDto>(fault);
        }

        public async Task<FaultReadDto>UpdateAsync(FaultUpdateDto faultUpdateDto)
        {
            var exictFault = await _faultRepository.GetByIdAsync(faultUpdateDto.Id);
            if(exictFault != null)
            {
                _mapper.Map(faultUpdateDto, exictFault);
                exictFault.SolvedAt = DateTime.Now;
                await _faultRepository.UpdateAsync(exictFault);
                return _mapper.Map<FaultReadDto>(exictFault);
            }
            else
            {
                throw new KeyNotFoundException($"Zone With Id #{faultUpdateDto.Id} Not Exist");
            }
        }

        public async Task <bool> DeleteAsync(int id)
        {
            var fault = await _faultRepository.GetByIdAsync(id);
            if(fault != null)
            {
                await _faultRepository.DeleteAsync(id);
                fault.SolvedAt = DateTime.Now;
                return true;
            }
            else
            {
                throw new KeyNotFoundException($"Fault With Id #{id} Not Exist");
            }
        }
    }
}
