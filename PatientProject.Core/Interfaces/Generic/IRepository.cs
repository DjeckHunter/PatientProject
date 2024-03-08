using PatientProject.Core.Entities;

namespace PatientProject.Core.Interfaces.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        void CreateRange(IEnumerable<T> entityList);
        void Update(T entity);
        void UpdateRange(List<T> entityList);
        void Delete(Guid id);
        void DeleteRange(List<T> entityList);
        IQueryable<T1> GetListResultSpec<T1>(Func<IQueryable<T>, IQueryable<T1>> func);
        T1 GetResultSpec<T1>(Func<IQueryable<T>, T1> func);
    }
}
