using Wing_Fleet_Manager.Dtos.Fault;
using Wing_Fleet_Manager.Dtos.Vehicle;
using Wing_Fleet_Manager.Dtos.Zone;
using X.PagedList;
using X.PagedList.Extensions;

namespace Wing_Fleet_Manager.ViewModel
{
    public class VehuclesViewModel
    {
        public IPagedList<VehicleReadDto>Vehicles { get; set; } = new List<VehicleReadDto>().ToPagedList(1,10);
        public VehicleCreateDto vehicleCreateDto { get; set; } = new VehicleCreateDto();
        public VehicleUpdateDto vehicleUpdateDto { get; set; } = new VehicleUpdateDto();
        public List<FaultReadDto> Faults { get; set; } = new List<FaultReadDto>();
        public IEnumerable<ZoneEnum>? ZonesEnum {  get; set; }
    }
}