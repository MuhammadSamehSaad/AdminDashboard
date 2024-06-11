using AutoMapper;
using Demo.DAL.Entites;
using Demo.PL.ViewModels;

namespace Demo.PL.Mappers
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
        }
    }
}
