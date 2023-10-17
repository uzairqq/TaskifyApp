using Microsoft.EntityFrameworkCore;
using Taskify_API.Dto;
using Taskify_API.Models;
using Task = Taskify_API.Models.Task;

namespace Taskify_API.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskifyDbContext _context;

        public TaskRepository(TaskifyDbContext context)
        {
            _context = context;
        }

        public async Task<Task> PostAsync(Task input)
        {
            try
            {
                var result = await _context.Tasks.AddAsync(input);
                await _context.SaveChangesAsync();
                return new Task()
                {
                    Id = result.Entity.Id,
                };
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<Task> PutAsync(Task input)
        {
            try
            {
                var result = _context.Tasks.Update(input);
                await _context.SaveChangesAsync();
                return new Task()
                {
                    Id = result.Entity.Id,
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Task> DeleteAsync(Task task)
        {
            try
            {
                var result = _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Task>> GetListAsync()
        {
            var result= await _context.Tasks.ToListAsync();
            return result;
        }

        public async Task<Task> GetByIdAsync(int id)
        {
            var result = await _context.Tasks.FindAsync(id);
            if (result == null)
            {
                return null;
            }
            return result;
        }

    }
}
