using Microsoft.AspNetCore.Mvc;
using Wing_Fleet_Manager.Dtos.Vehicle;
using Wing_Fleet_Manager.Dtos.Zone;
using Wing_Fleet_Manager.Services.Implementation;
using Wing_Fleet_Manager.Services.Interface;
using Wing_Fleet_Manager.ViewModel;
using X.PagedList.Extensions;

namespace Wing_Fleet_Manager.Controllers
{
    public class ZonesController : Controller
    {
        private readonly IZoneService _zoneService;
        public ZonesController(IZoneService zoneService)
        {
            _zoneService = zoneService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;


            var zones = await _zoneService.GetAllAsync();
            foreach (var zone in zones)
            {
                zone.VehiclesCount = await _zoneService.VehiclesCountByZoneId(zone.Id);
            }


            var ZonesPagedList = zones.ToPagedList(pageNumber, pageSize);
            var vm = new ZonesViewModel
            {
                Zones = ZonesPagedList,
                zoneCreateDto = new ZoneCreateDto(),
                zoneUpdateDto = new ZoneUpdateDto(),
            };

            return View(vm);
        }

        public async Task<IActionResult> Create(ZoneCreateDto zoneCreateDto)
        {
            if (!ModelState.IsValid)
            {
                int pageSize = 10;
                int pageNumber = 1;

                var zones = await _zoneService.GetAllAsync();
                var ZonesPagedList = zones.ToPagedList(pageNumber, pageSize);


                var vm = new ZonesViewModel
                {
                     Zones = ZonesPagedList,
                    zoneCreateDto = new ZoneCreateDto(),
                    zoneUpdateDto = new ZoneUpdateDto(),
                };
                return View(vm);
            }



            await _zoneService.AddAsync(zoneCreateDto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ZoneUpdateDto zoneUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            await _zoneService.UpdateAsync(zoneUpdateDto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _zoneService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }

}
