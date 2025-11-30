using Wing_Fleet_Manager.Dtos.User;
using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Repository.Interface
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task<List<User>> GetByNameAsync(string name);
        Task<User> AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}
