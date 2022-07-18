using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Webshop_WPF.Repositories
{
    public class GenericRepository<TEntity, TContext> :
        IGenericRepository<TEntity>
        where TEntity : class // egy táblát jelöl
        where TContext : DbContext // db kapcsolat
    {
        protected TContext _context; // Adatbázis kapcsolatot jelöl, generikus
        public GenericRepository(TContext context)
        {
            _context = context;
        }
        public virtual List<TEntity> GetAll()
        {
            // Bármilyen típusú táblát visszaad
            return _context.Set<TEntity>().ToList();
        }
        public virtual TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            
        }

        public virtual void Update(TEntity entity)
        {
            _context.Update(entity);
            // a rekordot módosítottnak jelöli, majd elmenti
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public virtual void Delete(int id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            if (entity != null)
            {
                _context.Remove(entity);
                _context.SaveChanges();
            }
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }
    }
}