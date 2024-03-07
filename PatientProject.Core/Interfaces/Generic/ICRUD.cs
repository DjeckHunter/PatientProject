using PatientProject.Core.DTOs;

namespace PatientProject.Core.Interfaces.Generic
{
    public interface ICRUD<T> where T : BaseDTO
    {
        void Create(T entityDTO);
        void Update(T entityDTO);
        T GetById(int id);
        void Delete(int id);
    }
}
