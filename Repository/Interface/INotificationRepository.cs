using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Repository.Interface
{
    public interface INotificationRepository
    {
        public Task<List<Notification>> GetAllAsync();
        public Task<Notification> GetByIdAsync(int id);
        public Task AddAsync(Notification notification);
        public Task UpdateAsync(Notification notification);
        public Task DeleteAsync(int id);
    }
}
