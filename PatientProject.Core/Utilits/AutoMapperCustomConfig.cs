using AutoMapper;
using PatientProject.Core.DTOs.Patient;
using PatientProject.Core.Entities;

namespace PatientProject.Core.Utilits
{
    internal class AutoMapperCustomConfig
    {
        public static PatientResponseDTO AutoMapPatient(IQueryable<Patient> querable)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Patient, PatientResponseDTO>()
                    .ForMember(dist => dist.Gender, opt => opt.MapFrom(src => src.Gender.Name));
            });

            var mapper = new Mapper(config);
            return new Mapper(config).ProjectTo<PatientResponseDTO>(querable, null).FirstOrDefault();
        }

        public static IEnumerable<PatientResponseDTO> AutoMapListPatient(IQueryable<Patient> querable)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Patient, PatientResponseDTO>()
                    .ForMember(dist => dist.Gender, opt => opt.MapFrom(src => src.Gender.Name));
            });

            var mapper = new Mapper(config);
            return new Mapper(config).ProjectTo<PatientResponseDTO>(querable, null);
        }
    }
}
