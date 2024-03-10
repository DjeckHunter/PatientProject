using PatientProject.Core.DTOs.Patient;
using PatientProject.Core.Entities;
using PatientProject.Core.Enums;
using PatientProject.Core.Interfaces.Generic;
using PatientProject.Core.Interfaces.Services;
using PatientProject.Core.Utilits;
using System.Linq.Expressions;

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

        public void Delete(Guid id) => _patientRepository.Delete(id);

        public PatientResponseDTO GetById(Guid id) => 
            AutoMapperCustomConfig.AutoMapPatient(_patientRepository.GetResultSpec(q => q.Where(p => p.Id.Equals(id))));

        public bool IsExists(Guid id) => _patientRepository.GetResultSpec(x => x.Any(a => a.Id.Equals(id)));

        public IEnumerable<PatientResponseDTO> List(bool isActive, List<string> parametrs)
        {
            Expression<Func<Patient, bool>> predicate = PredicateBuilder.True<Patient>().And(p => p.IsActive == isActive);
            foreach (var parametr in parametrs)
                predicate = CreatePredicate(predicate, parametr);

            return AutoMapperCustomConfig.AutoMapListPatient(_patientRepository.GetResultSpec(q => q.Where(predicate)));
        }

        public void ToggleState(Guid id)
        {
            var patient = _patientRepository.GetResultSpec(q => q.Where(p => p.Id.Equals(id))).FirstOrDefault();
            patient.IsActive = !patient.IsActive;
            _patientRepository.Update(patient);
        }

        public void Update(PatientUpdateRequestDTO model) => 
            _patientRepository.Update(AutoMapperConfig.AutoMap<PatientUpdateRequestDTO, Patient>(model));


        //TODO
        private Expression<Func<Patient, bool>> CreatePredicate(Expression<Func<Patient, bool>> predicate, string parametr)
        {
            var prefix = parametr[..2];
            var date = Convert.ToDateTime(parametr[2..]);
            bool hasTime = date.TimeOfDay != TimeSpan.Zero;

            switch (prefix)
            {
                case nameof(DatePredication.eq):
                    if(hasTime)
                        return predicate = predicate.And(p => p.BirthDate  == date);
                    else
                        return predicate = predicate.And(p => p.BirthDate.Date  == date.Date);
                case nameof(DatePredication.ne):
                    if (hasTime)
                        return predicate = predicate.And(p => p.BirthDate != date);
                    else
                        return predicate = predicate.And(p => p.BirthDate.Date != date.Date);
                case nameof(DatePredication.lt):
                    if (hasTime)
                        return predicate = predicate.And(p => p.BirthDate < date);
                    else
                        return predicate = predicate.And(p => p.BirthDate.Date < date.Date);
                case nameof(DatePredication.gt):
                    if (hasTime)
                        return predicate = predicate.And(p => p.BirthDate > date);
                    else
                        return predicate = predicate.And(p => p.BirthDate.Date > date.Date);
                case nameof(DatePredication.ge):
                    if (hasTime)
                        return predicate = predicate.And(p => p.BirthDate >= date);
                    else
                        return predicate = predicate.And(p => p.BirthDate.Date >= date.Date);
                case nameof(DatePredication.le):
                    if (hasTime)
                        return predicate = predicate.And(p => p.BirthDate <= date);
                    else
                        return predicate = predicate.And(p => p.BirthDate.Date <= date.Date);
                case nameof(DatePredication.sa):
                    throw new NotImplementedException();
                case nameof(DatePredication.eb):
                    throw new NotImplementedException();
                case nameof(DatePredication.ap):
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
