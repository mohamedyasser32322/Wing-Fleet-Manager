using AutoMapper;
using Wing_Fleet_Manager.Dtos.User;
using Wing_Fleet_Manager.Helpers;
using Wing_Fleet_Manager.Models;
using Wing_Fleet_Manager.Repository.Interface;
using Wing_Fleet_Manager.Services.Interface;

namespace Wing_Fleet_Manager.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<List<UserReadDto>> GetAllAsync()
        {
            var users = await _userRepo.GetAllAsync();
            return _mapper.Map<List<UserReadDto>>(users);
        }

        public async Task<UserReadDto?> GetByIdAsync(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if(user != null)
            {
                return _mapper.Map<UserReadDto>(user);
            }
            else
            {
                return null;
            }
        }

        public async Task<UserReadDto> AuthAsync(UserLoginDto login)
        {
            var user = await _userRepo.GetByEmailAsync(login.Email);
            if (user == null)
            {
                throw new ArgumentException("Invalid Email Or Password");
            }

            bool isPasswordValid = PasswordHelper.VerifyPassword(user.HashPassword, login.Password);
            if (!isPasswordValid)
            {
                throw new ArgumentException("Invalid Email Or Password");
            }

            if(user.IsDeleted || !user.IsActive)
            {
                throw new ArgumentException("Invalid Email Or Password");
            }
            user.LastLoginAt = DateTime.UtcNow;
            await _userRepo.UpdateAsync(user);

            return _mapper.Map<UserReadDto>(user);
        }

        public async Task<UserReadDto> AddAsync(UserCreateDto userCreateDto)
        {
            var exictingUser = await _userRepo.GetByEmailAsync(userCreateDto.Email);
            if(exictingUser != null)
            {
                throw new ArgumentException("Email Is Already Registered");
            }

            var userEntity = _mapper.Map<User>(userCreateDto);

            var newUser = await _userRepo.AddAsync(userEntity);

            return _mapper.Map<UserReadDto>(newUser);
        }

        public async Task<UserReadDto> UpdateAsync(UserUpdateDto userUpdateDto)
        {
            var userEntity = await _userRepo.GetByIdAsync(userUpdateDto.Id);
            if (userEntity == null)
            {
                throw new ArgumentException($"User With Id #{userUpdateDto.Id} Not Found");
            }

            _mapper.Map(userUpdateDto, userEntity);

            userEntity.LastUpDatedAt = DateTime.UtcNow;

            await _userRepo.UpdateAsync(userEntity);

            return _mapper.Map<UserReadDto>(userEntity);
        }

        public async Task ChangePasswordAsync(UserChangePasswordDto changePasswordDto)
        {
            var userEntity = await _userRepo.GetByIdAsync(changePasswordDto.Id);
            if(userEntity == null)
            {
                throw new ArgumentException($"User With Id #{changePasswordDto.Id} Not Found");
            }

            var verifyOldPassword = PasswordHelper.VerifyPassword(userEntity.HashPassword, changePasswordDto.CurrentPassword);
            if (!verifyOldPassword)
            {
                throw new ArgumentException("Wrong Password");
            }

            userEntity.HashPassword = PasswordHelper.PasswordHasher(changePasswordDto.NewPassword);

            userEntity.LastUpDatedAt = DateTime.UtcNow;
            await _userRepo.UpdateAsync(userEntity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var userEntity = await _userRepo.GetByIdAsync(id);
            if(userEntity == null)
            {
                throw new ArgumentException($"User With Id #{id} Not Found");
            }

            await _userRepo.DeleteAsync(id);
            userEntity.LastUpDatedAt = DateTime.UtcNow;
            return true;
        }
    }
}