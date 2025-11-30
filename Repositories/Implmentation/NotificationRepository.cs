using Microsoft.EntityFrameworkCore;
using Wing_Fleet_Manager.Data;
using Wing_Fleet_Manager.Models;
using Wing_Fleet_Manager.Repository.Interface;

namespace Wing_Fleet_Manager.Repository.Implmentation
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly WingDbContext _context;
        public NotificationRepository(WingDbContext context)
        {
            _context = context;
        }

        public async Task<List<Notification>> GetAllAsync()
        {
            return await _context.Notifications.ToListAsync();
        }

        public async Task<Notification?> GetByIdAsync(int id)
        {
            return await _context.Notifications.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task AddAsync(Notification notification)
        {
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Notification notification)
        {
            _context.Notifications.Update(notification);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Notification = await _context.Notifications.FindAsync(id);
            if (Notification != null)
            {
                _context.Notifications.Remove(Notification);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Notification With Id #{id} Is Not Found");
            }
        }
    }
}
