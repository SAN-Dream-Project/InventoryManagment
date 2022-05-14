using Inventory.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Inventory.EntityFramwork.Abstract;
using System.Linq.Expressions;

namespace Inventory.EntityFramwork.Repositories
{
   public class EntityBaseRepository<T> : IEntityBaseRepository<T>
            where T : class, IEntityBase, new()
    {

        private InventoryContext _context;

        #region Properties
        public EntityBaseRepository(InventoryContext context)
        {
            _context = context;
        }
        #endregion
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            var result = _context.Set<T>().AsEnumerable();
            Commit();
            return result;
        }

        public virtual int Count()
        {
            return _context.Set<T>().Count();
           
        }
        public virtual IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            Commit();
            return query.AsEnumerable();  
            
        }

        public async Task<T> GetSingle(Guid id)
        {
            var result = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            Commit();
            return result;
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            var result = _context.Set<T>().FirstOrDefault(predicate);
            Commit();
            return result;
        }

        public T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Where(predicate).FirstOrDefault();
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            var result = _context.Set<T>().AsNoTracking().Where(predicate);
            Commit();
            return result;
        }

        public virtual async Task<T> Add(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            await _context.Set<T>().AddAsync(entity);
            Commit();
            return entity;
        }

        public virtual async Task<T> Update(T entity)
        {
            entity.ModifiedDate = DateTime.Now;
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
            Commit();
            return entity;
        }
        public virtual async Task Delete(T entity)
        {
            EntityEntry dbEntityEntry =  _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted; 
            Commit();
        }

        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _context.Set<T>().Where(predicate);

            foreach(var entity in entities)
            {
                _context.Entry<T>(entity).State = EntityState.Deleted;
            }
        }

        public virtual void Commit()
        {
             _context.SaveChanges();
        }
    }
}
