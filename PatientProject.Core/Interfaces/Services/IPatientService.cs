using PatientProject.Core.DTOs.Patient;

namespace PatientProject.Core.Interfaces.Services
{
    public interface IPatientService
    {
        void Create(PatientCreateRequestDTO model);
        void Update(PatientUpdateRequestDTO model);
        PatientResponseDTO GetById(Guid id);
        IEnumerable<PatientResponseDTO> List(bool isActive);
        void Delete(Guid id);
        void ToggleState(Guid id);
        bool IsExists(Guid id);
    }
}
