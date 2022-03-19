using LeaveManagementSystemIndividual.Contracts;
using LeaveManagementSystemIndividual.Data;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystemIndividual.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ApplicationDbContext context;

        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            this.context = applicationDbContext;
        }
        public async Task<T> CreateAsync(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var ent = await context.Set<T>().FindAsync(id);
            if (ent != null)
                return true;
            return false;
        }

        public async Task<List<T>> GetAllAsync()
        {
            var entities = await context.Set<T>().ToListAsync();
            return entities;
        }

        public async Task<T> GetAsync(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
#pragma warning disable CS8603 // Possible null reference return.
            return entity;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<T> UpdateAsync(T entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
