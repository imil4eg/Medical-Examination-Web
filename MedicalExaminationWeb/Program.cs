using MedicalExamination.DAL;
using MedicalExamination.Entities;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalExaminationWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<MedicalExaminationContext>();
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();  
                var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();

                var dbInitializer = new DbInitializer(context, userManager, roleManager);
               dbInitializer.Initialize().Wait();
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
