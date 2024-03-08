using AutoMapper;

namespace PatientProject.Core.Utilits
{
    internal static class AutoMapperConfig
    {
        public static T1 AutoMap<T, T1>(T model)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<T, T1>());
            var mapper = new Mapper(config);
            return mapper.Map<T, T1>(model);
        }

        public static T AutoMap<T, T1>(IQueryable<T1> querable)
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<T1, T>();
            });

            return new Mapper(config).ProjectTo<T>(querable, null).FirstOrDefault();
        }

        public static IEnumerable<T> AutoMapList<T, T1>(IQueryable<T1> querable)
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<T1, T>();
            });

            return new Mapper(config).ProjectTo<T>(querable, null).AsEnumerable();
        }
    }
}
