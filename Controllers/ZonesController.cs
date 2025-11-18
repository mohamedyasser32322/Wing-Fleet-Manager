using Microsoft.AspNetCore.Mvc;
using Wing_Fleet_Manager.Services.Interface;

namespace Wing_Fleet_Manager.Controllers
{
    public class ZonesController : Controller
    {
        private readonly IZoneService _zoneService;
        public ZonesController(IZoneService zoneService)
        {
            _zoneService = zoneService;
        }
        public async Task<IActionResult> Index()
        {
            var zones = await _zoneService.GetAllAsync();
            return View(zones);
        }
    }
}
