using System;
using AutoMapper;
using SynetecAssessmentApi.Domain.Concrete;
using SynetecAssessmentApi.Domain.Dtos;

namespace SyntecAssessmentApi.Services.AutoMapper.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();

        }
    }
}
