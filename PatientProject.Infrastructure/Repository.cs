using Microsoft.EntityFrameworkCore;
using PatientProject.Core.Entities;
using PatientProject.Core.Interfaces.Generic;

namespace PatientProject.Infrastructure
{
    internal class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly RepositoryContext _context;

        public Repository(RepositoryContext context) => _context = context;

        public void Create(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void CreateRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
        }

        public void DeleteRange(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Set<T>().SingleOrDefault(x => x.Id == id);
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            var local = _context.Set<T>().Local.FirstOrDefault(l => l.Id.Equals(entity.Id));
            if (local != null)
                _context.Entry(local).State = EntityState.Detached;

            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdateRange(List<T> entities)
        {
            entities.ForEach(l => _context.Entry(l).State = EntityState.Modified);
            _context.SaveChanges();
        }

        public IQueryable<T1> GetListResultSpec<T1>(Func<IQueryable<T>, IQueryable<T1>> func) => func(_context.Set<T>().AsNoTracking());
        public T1 GetResultSpec<T1>(Func<IQueryable<T>, T1> func) => func(_context.Set<T>().AsNoTracking());
    }
}
