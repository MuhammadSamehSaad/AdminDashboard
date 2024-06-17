using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Demo.PL.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.PL.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddAutoMapper(M => M.AddProfile(new EmployeeProfile()));
            services.AddAutoMapper(M => M.AddProfile(new DepartmentProfile()));
            services.AddScoped<IUniteOfWork, UniteOfWork>();

        }

    }
}
