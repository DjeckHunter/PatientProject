using PatientProject.Core.DTOs.Gender;
using PatientProject.Core.Entities;
using PatientProject.Core.Interfaces.Generic;
using PatientProject.Core.Interfaces.Services;
using PatientProject.Core.Utilits;

namespace PatientProject.Core.Services
{
    public class GenderService : IGenderService
    {
        private readonly IRepository<Gender> _genderRepository;

        public GenderService(IRepository<Gender> genderRepository) => _genderRepository = genderRepository;

        public void Create(string name) => _genderRepository.Create(new Gender { Name = name, IsActive = true });

        public void ToggleState(int id)
        {
            var gender = _genderRepository.GetResultSpec(q => q.Where(p => p.Id == id)).FirstOrDefault();
            gender.IsActive = !gender.IsActive;
            _genderRepository.Update(gender);
        }

        public bool IsExists(int id) => _genderRepository.GetResultSpec(x => x.Any(a => a.Id == id));
        public bool IsExists(string name) => _genderRepository.GetResultSpec(x => x.Any(a => a.Name == name));

        public void Update(GenderUpdateRequest model) => _genderRepository.Update(AutoMapperConfig.AutoMap<GenderUpdateRequest, Gender>(model));

        public IEnumerable<GenderResponseDTO> List(bool isActive) => 
            AutoMapperConfig.AutoMapList<GenderResponseDTO, Gender>(_genderRepository.GetListResultSpec(q => q.Where(p => p.IsActive == isActive)));

        public void Delete(int id) => _genderRepository.Delete(id);
    }
}
