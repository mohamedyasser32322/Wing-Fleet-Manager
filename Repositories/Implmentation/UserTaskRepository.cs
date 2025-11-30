using Microsoft.EntityFrameworkCore;
using Wing_Fleet_Manager.Data;
using Wing_Fleet_Manager.Models;
using Wing_Fleet_Manager.Repository.Interface;

namespace Wing_Fleet_Manager.Repository.Implmentation
{
    public class UserTaskRepository : IUserTaskRepository
    {
        private readonly WingDbContext _context;
        public UserTaskRepository(WingDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserTask>> GetAllAsync()
        {
            return await _context.UserTasks.ToListAsync();
        }

        public async Task<UserTask?> GetByIdAsync(int id)
        {
            return await _context.UserTasks.FirstOrDefaultAsync(ut => ut.Id == id);
        }

        public async Task AddAsync(UserTask userTask)
        {
            await _context.UserTasks.AddAsync(userTask);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserTask userTask)
        {
            _context.UserTasks.Update(userTask);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var UserTask = await _context.UserTasks.FindAsync(id);
            if (UserTask != null)
            {
                _context.UserTasks.Remove(UserTask);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Task With Id #{id} Is Not Found");
            }
        }
    }
}
