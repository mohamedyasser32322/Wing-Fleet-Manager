using Microsoft.AspNetCore.Mvc;
using Wing_Fleet_Manager.Services.Interface;

namespace Wing_Fleet_Manager.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllAsync();
            return View(users);
        }
    }
}
