using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Wing_Fleet_Manager.Dtos.User;
using Wing_Fleet_Manager.Services.Interface;
using Wing_Fleet_Manager.ViewModel;
using X.PagedList.Extensions;

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
        [Authorize]
        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);


            var users = await _userService.GetAllAsync();
            var usersPagedList = users.ToPagedList(pageNumber, pageSize);


            var vm = new UsersViewModel
            {
                Users = usersPagedList,
                CreateUser = new UserCreateDto(),
                UpdateUser = new UserUpdateDto()
            };

            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateDto userCreateDto)
        {
            if (!ModelState.IsValid)
            {
                var users = await _userService.GetAllAsync();
                int pageSize = 10;
                int pageNumber = 1;

                var usersPagedList = users.ToPagedList(pageNumber, pageSize);



                var viewModel = new UsersViewModel
                {
                    Users = usersPagedList,
                    CreateUser = userCreateDto,
                    UpdateUser = new UserUpdateDto()
                };

                return View("Index",viewModel);
            }
            await _userService.AddAsync(userCreateDto);
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
