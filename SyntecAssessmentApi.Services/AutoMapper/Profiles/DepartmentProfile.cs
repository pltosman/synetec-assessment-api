using System;
using AutoMapper;
using SynetecAssessmentApi.Domain.Concrete;
using SynetecAssessmentApi.Domain.Dtos;

namespace SyntecAssessmentApi.Services.AutoMapper.Profiles
{
    public class DepartmentProfile: Profile
    {
        public DepartmentProfile()
    {
        CreateMap<Department, DepartmentDto>().ReverseMap();

    }
}
}
