using PatientProject.Core.DTOs.Patient;

namespace PatientProject.Core.Interfaces.Services
{
    public interface IPatientService
    {
        void Create(PatientCreateRequestDTO model);
        void Update(PatientUpdateRequestDTO model);
        PatientResponseDTO GetById(int id);
        IEnumerable<PatientResponseDTO> List(bool isActive);
        void Delete(int id);
        void ToggleState(int id);
        bool IsExists(int id);
    }
}
