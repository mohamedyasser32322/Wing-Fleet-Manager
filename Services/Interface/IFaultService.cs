using Wing_Fleet_Manager.Dtos.Fault;

namespace Wing_Fleet_Manager.Services.Interface
{
    public interface IFaultService
    {
        public Task<List<FaultReadDto>> GetAllAsync();
        public Task<FaultReadDto> GetByIdAsunc(int id);
        public Task<int> CountAsync();
        public Task <FaultReadDto>AddAsync(FaultCreateDto faultCreateDto);
        public Task <FaultReadDto>UpdateAsync(FaultUpdateDto faultUpdateDto);
        public Task <bool>DeleteAsync(int id);
    }
}
