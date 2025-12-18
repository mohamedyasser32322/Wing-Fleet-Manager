using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wing_Fleet_Manager.Dtos.User;
using Wing_Fleet_Manager.Dtos.Vehicle;
using Wing_Fleet_Manager.Dtos.Zone;
using Wing_Fleet_Manager.Services.Implementation;
using Wing_Fleet_Manager.Services.Interface;
using Wing_Fleet_Manager.ViewModel;
using X.PagedList.Extensions;

namespace Wing_Fleet_Manager.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IZoneService _zoneService;
        private readonly IVehicleService _vehicleService;
        public VehiclesController(IVehicleService vehicleService , IZoneService zoneService)
        {
            _vehicleService = vehicleService;
            _zoneService = zoneService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);


            var vehicles = await _vehicleService.GetAllAsync();
            var zones = await _zoneService.GetZones();
            var vehiclesPagedList = vehicles.ToPagedList(pageNumber, pageSize);

            var vm = new VehuclesViewModel
            {
                Vehicles = vehiclesPagedList,
                vehicleCreateDto = new VehicleCreateDto(),
                vehicleUpdateDto = new VehicleUpdateDto(),
                ZonesEnum = zones
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(VehicleCreateDto vehicleCreateDto)
        {
            if (!ModelState.IsValid)
            {
                int pageSize = 10;
                int pageNumber = 1;

                var vehicles = await _vehicleService.GetAllAsync();
                var vehiclesPagedList = vehicles.ToPagedList(pageNumber, pageSize);
                var zonesList = await _zoneService.GetZones();


                var vm = new VehuclesViewModel
                {
                    Vehicles = vehiclesPagedList,
                    vehicleCreateDto = new VehicleCreateDto(),
                    vehicleUpdateDto = new VehicleUpdateDto(),
                    ZonesEnum = zonesList
                };
                return View(vm);
            }



            await _vehicleService.AddAsync(vehicleCreateDto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(VehicleUpdateDto vehicleUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            await _vehicleService.UpdateAsync(vehicleUpdateDto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _vehicleService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
