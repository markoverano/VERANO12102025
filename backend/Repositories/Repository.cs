using Microsoft.EntityFrameworkCore;
using VideoStore.Backend.Data;

namespace VideoStore.Backend.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly VideoContext Context;
        protected readonly DbSet<T> DbSet;

        public Repository(VideoContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            DbSet.Add(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            DbSet.Update(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            var entity = await DbSet.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            DbSet.Remove(entity);
            await Context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> ExistsAsync(int id)
        {
            var entity = await DbSet.FindAsync(id);
            return entity != null;
        }
    }
}
