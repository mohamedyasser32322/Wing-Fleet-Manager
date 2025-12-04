using Microsoft.EntityFrameworkCore;
using Wing_Fleet_Manager.Data;
using Wing_Fleet_Manager.Models;
using Wing_Fleet_Manager.Repository.Interface;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace Wing_Fleet_Manager.Repository.Implmentation
{
    public class UserRepository : IUserRepository
    {
        private readonly WingDbContext _context;
        public UserRepository(WingDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users
                .Where(u => !u.IsDeleted)
                .Include(u => u.Role)
                .ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?>GetByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<List<User>> GetByNameAsync(string name)
        {
            return await _context.Users
                    .Where(u => u.FullName != null &&
                    EF.Functions.Like(u.FullName.ToLower(), $"%{name.ToLower()}%"))
                .ToListAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Users
                .Where(u => !u.IsDeleted)
                .CountAsync();
        }

        public async Task<User> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            
            if (user != null)
            {
                user.IsDeleted = true;
                user.LastUpDatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"User With Id #{id} Not Found");
            }
        }
    }
}
