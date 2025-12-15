using Wing_Fleet_Manager.Dtos.Fault;
using X.PagedList;
using X.PagedList.Extensions;

namespace Wing_Fleet_Manager.ViewModel
{
    public class DashBoardViewModel
    {
        public int TotalVehicles { get; set; }
        public int TotalUsers { get; set; }
        public int TotalZones { get; set; }
        public int TotalFaults { get; set; }
        public IPagedList<FaultReadDto> Faults { get; set; } = new List<FaultReadDto>().ToPagedList();
    }
}