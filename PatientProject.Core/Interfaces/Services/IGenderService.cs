using PatientProject.Core.DTOs.Gender;

namespace PatientProject.Core.Interfaces.Services
{
    public interface IGenderService
    {
        bool IsExists(Guid id);
        bool IsExists(string name);
        void ToggleState(Guid id);
        void Create(string name);
        void Update(GenderUpdateRequest model);
        IEnumerable<GenderResponseDTO> List(bool isActive);
        void Delete(Guid id);
    }
}
