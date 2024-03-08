using Microsoft.Extensions.DependencyInjection;
using PatientProject.Core.Interfaces.Services;
using PatientProject.Core.Services;

namespace PatientProject.Core
{
    public static class StartupCore
    {
        public static void AddServicesImplementation(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPatientService), typeof(PatientService));
            services.AddScoped(typeof(IGenderService), typeof(GenderService));
        }
    }
}
