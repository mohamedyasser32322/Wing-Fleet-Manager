using Wing_Fleet_Manager.Dtos.User;

namespace Wing_Fleet_Manager.ViewModel
{
    public class UsersViewModel
    {
        public List<UserReadDto> Users { get; set; } = new List<UserReadDto>();
        public UserCreateDto CreateUser { get; set; } = new UserCreateDto();
        public UserUpdateDto UpdateUser { get; set; } = new UserUpdateDto();
        public UserLoginDto UserLoginDto { get; set; } = new UserLoginDto();
    }
}
