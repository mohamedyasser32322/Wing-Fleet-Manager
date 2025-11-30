using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Wing_Fleet_Manager.Dtos.User;
using Wing_Fleet_Manager.Services.Interface;
using Wing_Fleet_Manager.ViewModel;

namespace Wing_Fleet_Manager.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllAsync();
            var vm = new UsersViewModel
            {
                Users = users,
                CreateUser = new UserCreateDto(),
                UpdateUser = new UserUpdateDto()
            };

            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsersViewModel usersViewModel)
        {
            if (!ModelState.IsValid)
            {
                usersViewModel.Users = await _userService.GetAllAsync();
                return View("Index",usersViewModel);
            }
            await _userService.AddAsync(usersViewModel.CreateUser);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Update(UserUpdateDto userUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            await _userService.UpdateAsync(userUpdateDto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Delete(int id)
        {
           await _userService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
