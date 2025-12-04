using Wing_Fleet_Manager.Dtos.User;
using X.PagedList;
using X.PagedList.Extensions;

namespace Wing_Fleet_Manager.ViewModel
{
    public class UsersViewModel
    {
        public IPagedList<UserReadDto> Users { get; set; } = new List<UserReadDto>().ToPagedList(1, 10);
        public UserCreateDto CreateUser { get; set; } = new UserCreateDto();
        public UserUpdateDto UpdateUser { get; set; } = new UserUpdateDto();
        public UserLoginDto UserLoginDto { get; set; } = new UserLoginDto();
    }
}
