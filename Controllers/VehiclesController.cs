using Microsoft.AspNetCore.Mvc;
using Wing_Fleet_Manager.Services.Interface;

namespace Wing_Fleet_Manager.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehicleService _vehicleService;
        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public async Task<IActionResult> Index()
        {
            var vehicles = await _vehicleService.GetAllAsync();
            return View(vehicles);
        }
    }
}
