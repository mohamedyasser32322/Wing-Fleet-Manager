using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Wing_Fleet_Manager.Dtos.Fault;
using Wing_Fleet_Manager.Dtos.Vehicle;
using Wing_Fleet_Manager.Dtos.Zone;
using Wing_Fleet_Manager.Models;
using Wing_Fleet_Manager.Services.Implementation;
using Wing_Fleet_Manager.Services.Interface;
using Wing_Fleet_Manager.ViewModel;
using X.PagedList.Extensions;

namespace Wing_Fleet_Manager.Controllers
{
    public class FaultsController : Controller
    {
        private readonly IFaultService _faultService;
        private readonly IVehicleService _vehicleService;
        private readonly IZoneService _zoneService;
        private readonly IUserService _userService;
        public FaultsController(IFaultService faultService, IVehicleService vehicleService, IZoneService zoneService,IUserService userService)
        {
            _faultService = faultService;
            _vehicleService = vehicleService;
            _zoneService = zoneService;
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        public async Task <IActionResult> Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;

            var faults = await _faultService.GetAllAsync();
            var zones = await _zoneService.GetZones();
            var vehicles = await _vehicleService.GetVehicles();
            var users = await _userService.GetUsers();
            var FaultsPagedList = faults.ToPagedList(pageNumber, pageSize);

            var vm = new FaultsViewModel
            {
                Faults = FaultsPagedList,
                faultCreateDto = new FaultCreateDto(),
                faultUpdateDto = new FaultUpdateDto(),
                ZonesEnum = zones,
                VehiclesEnum = vehicles,
                UsersEnum = users,
            };

           

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FaultCreateDto faultCreateDto)
        {
            if (!ModelState.IsValid)
            {
                int pageSize = 10;
                int pageNumber = 1;

                var faults = await _faultService.GetAllAsync() ?? new List<FaultReadDto>();
                var FaultsPagedList = faults.ToPagedList(pageNumber,pageSize);
                var vehicles = await _vehicleService.GetVehicles();
                var zones = await _zoneService.GetZones();
                var users = await _userService.GetUsers();


                var vm = new FaultsViewModel
                {
                    Faults = FaultsPagedList,
                    faultCreateDto = new FaultCreateDto(),
                    faultUpdateDto = new FaultUpdateDto(),
                    ZonesEnum = zones,
                    VehiclesEnum = vehicles,
                    UsersEnum = users
                };
                return View(vm);
            }

            await _faultService.AddAsync(faultCreateDto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(FaultUpdateDto faultUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            await _faultService.UpdateAsync(faultUpdateDto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _faultService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
