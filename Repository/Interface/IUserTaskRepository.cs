using Wing_Fleet_Manager.Models;

namespace Wing_Fleet_Manager.Repository.Interface
{
    public interface IUserTaskRepository
    {
        public Task<List<UserTask>> GetAllAsync();
        public Task<UserTask> GetByIdAsync(int id);
        public Task AddAsync(UserTask userTask);
        public Task UpdateAsync(UserTask userTask);
        public Task DeleteAsync(int id);
    }
}
