using System.Linq;
using MedicalExamination.BLL;
using MedicalExamination.DAL;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalExaminationWeb
{
    /// <summary>
    /// Class for Dependency Injection Services
    /// from MedicalExamination.BLL and Repositories from MedicalExamination.DAL
    /// </summary>
    public class BootStrapper
    {
        /// <summary>
        /// Configure dependency injection
        /// </summary>
        /// <param name="services"></param>
        public static void Configure(IServiceCollection services)
        {
            AddAllRepositories(services);
            AddAllServices(services);
        }

        /// <summary>
        /// Injects repositories
        /// </summary>
        /// <param name="services"></param>
        public static void AddAllRepositories(IServiceCollection services)
        {
            var allProviderTypes = System.Reflection.Assembly.GetAssembly(typeof(GenericRepository<>))
                .GetTypes();

            foreach (var implementation in allProviderTypes.Where(t => t.Name.EndsWith("Repository") && t.IsClass))
            {
                var repositoryAbstraction = implementation.GetInterfaces();

                if (repositoryAbstraction.Length > 0)
                {
                    services.AddTransient(repositoryAbstraction[0], implementation);
                }
            }
        }

        /// <summary>
        /// Injects services
        /// </summary>
        /// <param name="services"></param>
        public static void AddAllServices(IServiceCollection services)
        {
            var serviceTypes = System.Reflection.Assembly.GetAssembly(typeof(IAppointmentService)).GetTypes();

            foreach (var serviceImplementation in serviceTypes.Where(s => s.IsClass))
            {
                var serviceAbstraction = serviceImplementation.GetInterfaces();

                if (serviceAbstraction.Length > 0)
                {
                    services.AddTransient(serviceAbstraction[0], serviceImplementation);
                }
            }
        }
    }
}
