using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Wing_Fleet_Manager.Models;
using Wing_Fleet_Manager.Services.Interface;
using Wing_Fleet_Manager.ViewModel;

namespace Wing_Fleet_Manager.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IVehicleService _vehicleService;
        private readonly IZoneService _zoneService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IVehicleService vehicleService, IUserService userService,IZoneService zoneService)
        {
            _logger = logger;
            _vehicleService = vehicleService;
            _userService = userService;
            _zoneService = zoneService;
        }

        [Authorize]
        public async Task <IActionResult> Index()
        {
            var stats = new DashBoardViewModel
            {
                TotalVehicles = await _vehicleService.CountAsync(),
                TotalUsers = await _userService.CountAsync(),
                TotalZones = await _zoneService.CountAsync(),
            };
            return View(stats);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
