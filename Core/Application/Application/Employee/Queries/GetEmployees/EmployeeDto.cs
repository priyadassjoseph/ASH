using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Application.Mappings;

namespace Application.Employee.Queries.GetEmployees
{
    public class EmployeeDto : IMapFrom<Domain.Entities.Employee>
    {
        public int Id { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Employee, EmployeeDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => (int)s.Id));
        }
    }
}
    