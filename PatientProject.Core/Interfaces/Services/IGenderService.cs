using PatientProject.Core.DTOs.Gender;

namespace PatientProject.Core.Interfaces.Services
{
    public interface IGenderService
    {
        bool IsExists(int id);
        bool IsExists(string name);
        void ToggleState(int id);
        void Create(string name);
        void Update(GenderUpdateRequest model);
        IEnumerable<GenderResponseDTO> List(bool isActive);
        void Delete(int id);
    }
}
