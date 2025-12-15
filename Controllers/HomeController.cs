using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using Wing_Fleet_Manager.Models;
using Wing_Fleet_Manager.Services.Interface;
using Wing_Fleet_Manager.ViewModel;
using X.PagedList.Extensions;

namespace Wing_Fleet_Manager.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IVehicleService _vehicleService;
        private readonly IZoneService _zoneService;
        private readonly IFaultService _faultService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IVehicleService vehicleService, IUserService userService,IZoneService zoneService,IFaultService faultService)
        {
            _logger = logger;
            _vehicleService = vehicleService;
            _userService = userService;
            _zoneService = zoneService;
            _faultService = faultService;
        }

        [Authorize]
        public async Task <IActionResult> Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;

            var faults = await _faultService.GetAllAsync();
            var FaultsPagedList = faults.ToPagedList(pageNumber, pageSize);

            var stats = new DashBoardViewModel
            {
                TotalVehicles = await _vehicleService.CountAsync(),
                TotalUsers = await _userService.CountAsync(),
                TotalZones = await _zoneService.CountAsync(),
                TotalFaults = await _faultService.CountAsync(),
                Faults = FaultsPagedList
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
            var errorModel = new ErrorViewModel()
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var exception = exceptionHandlerPathFeature?.Error;

            if (exception is SqlException sqlEx && (sqlEx.Number == 2601 || sqlEx.Number == 2627))
            {
                errorModel.ErrorMessage = "The value you’re trying to enter already exists";
                errorModel.StackTrace = null;
                return View(errorModel);
            }
            errorModel.ErrorMessage = exception?.Message;
            errorModel.StackTrace = exception?.StackTrace;

            return View(errorModel);
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
