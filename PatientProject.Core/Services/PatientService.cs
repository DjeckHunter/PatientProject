using PatientProject.Core.DTOs.Patient;
using PatientProject.Core.Entities;
using PatientProject.Core.Interfaces.Generic;
using PatientProject.Core.Interfaces.Services;
using PatientProject.Core.Utilits;

namespace PatientProject.Core.Services
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<Patient> _patientRepository;

        public PatientService(IRepository<Patient> patientRepository) => _patientRepository = patientRepository;

        public void Create(PatientCreateRequestDTO model)
        {
            var patient = AutoMapperConfig.AutoMap<PatientCreateRequestDTO, Patient>(model);
            patient.IsActive = true;
            _patientRepository.Create(patient);
        }

        public void Delete(int id) => _patientRepository.Delete(id);

        public PatientResponseDTO GetById(int id) =>
            AutoMapperCustomConfig.AutoMapPatient(_patientRepository.GetResultSpec(q => q.Where(p => p.Id == id)));

        public bool IsExists(int id) => _patientRepository.GetResultSpec(x => x.Any(a => a.Id == id));

        public IEnumerable<PatientResponseDTO> List(bool isActive) =>
            AutoMapperCustomConfig.AutoMapListPatient(_patientRepository.GetResultSpec(q => q.Where(p => p.IsActive == isActive)));

        public void ToggleState(int id)
        {
            var patient = _patientRepository.GetResultSpec(q => q.Where(p => p.Id == id)).FirstOrDefault();
            patient.IsActive = !patient.IsActive;
            _patientRepository.Update(patient);
        }

        public void Update(PatientUpdateRequestDTO model) => 
            _patientRepository.Update(AutoMapperConfig.AutoMap<PatientUpdateRequestDTO, Patient>(model));
    }
}
