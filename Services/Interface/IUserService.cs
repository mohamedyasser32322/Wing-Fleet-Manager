using Wing_Fleet_Manager.Dtos.User;

namespace Wing_Fleet_Manager.Services.Interface
{
    public interface IUserService
    {
        Task<List<UserReadDto>> GetAllAsync();
        Task<UserReadDto> GetByIdAsync(int id);
        Task <UserReadDto>AuthAsync(UserLoginDto login);
        Task <List<UserReadDto>>GetByNameAsync(string name);
        Task<int> CountAsync();
        Task <UserReadDto>AddAsync(UserCreateDto userCreateDto);
        Task <UserReadDto>UpdateAsync(UserUpdateDto userUpdateDto);
        Task ChangePasswordAsync(UserChangePasswordDto changePasswordDto);
        Task <bool>DeleteAsync(int id);
    }
}
