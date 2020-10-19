using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Employee.API.Services.Contracts;
using Application.Employee.Queries.GetEmployees;
using MediatR;
using Application.Employee.Commands;

namespace Employee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<EmployeeVm>> Get()
        {
            return await Mediator.Send(new GetEmployeesQuery());
        }

        [HttpGet("{id}")]
        public async Task<FileResult> Get(int id)
        {
            var vm = await Mediator.Send(new GetEmployeesQuery { Id = id });

            return File(vm.Content, vm.ContentType, vm.FileName);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateEmployeeCommand command)
        {
            return await Mediator.Send(command);
        }      
    }
}