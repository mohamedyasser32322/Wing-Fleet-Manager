using Wing_Fleet_Manager.Dtos.Fault;
using Wing_Fleet_Manager.Dtos.User;
using Wing_Fleet_Manager.Dtos.Vehicle;
using Wing_Fleet_Manager.Dtos.Zone;
using X.PagedList;
using X.PagedList.Extensions;

namespace Wing_Fleet_Manager.ViewModel
{
    public class FaultsViewModel
    {
        public IPagedList<FaultReadDto> Faults { get; set; } = new List<FaultReadDto>().ToPagedList();
        public FaultCreateDto faultCreateDto { get; set; } = new FaultCreateDto();
        public FaultUpdateDto faultUpdateDto { get; set; } = new FaultUpdateDto();
        public IEnumerable<ZoneEnum>? ZonesEnum { get; set; }
        public IEnumerable<VehicleEnum>? VehiclesEnum { get; set; }
        public IEnumerable<UserEnum>? UsersEnum { get; set; }
    }
}
