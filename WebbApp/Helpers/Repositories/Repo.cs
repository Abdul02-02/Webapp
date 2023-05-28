using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Webbapp.Contexts;

namespace Webbapp.Helpers.Repositories
{
    public abstract class Repo<Entity> where Entity : class
    {
        private readonly IdentityContext _context;

        protected Repo(IdentityContext context)
        {
            _context = context;
        }
        public virtual async Task<Entity> AddAsync(Entity entity)
        {
            await _context.Set<Entity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<Entity> GetAsync(Expression<Func<Entity, bool>> expression)
        {
            var entity = await _context.Set<Entity>().FirstOrDefaultAsync(expression);
            return entity!;
        }
        public virtual async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await _context.Set<Entity>().ToListAsync();
        }

        public virtual async Task<IEnumerable<Entity>> GetAllAsync(Expression<Func<Entity, bool>> expression)
        {
            return await _context.Set<Entity>().Where(expression).ToListAsync();
        }

        public virtual async Task<Entity> UpdateAsync(Entity entity)
        {
            _context.Set<Entity>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<Entity> RemoveAsync(Entity entity)
        {
            _context.Set<Entity>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}

