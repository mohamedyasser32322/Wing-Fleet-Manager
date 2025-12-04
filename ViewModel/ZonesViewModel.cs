using Wing_Fleet_Manager.Dtos.Zone;
using X.PagedList;
using X.PagedList.Extensions;

namespace Wing_Fleet_Manager.ViewModel
{
    public class ZonesViewModel
    {
        public IPagedList<ZoneReadDto> Zones { get; set; } = new List<ZoneReadDto>().ToPagedList(1,10);
        public ZoneCreateDto zoneCreateDto { get; set; } = new ZoneCreateDto();
        public ZoneUpdateDto zoneUpdateDto { get; set; } = new ZoneUpdateDto();
    }
}
