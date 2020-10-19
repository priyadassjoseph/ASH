using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Employee.Queries.GetEmployees
{
    public class GetEmployeesQuery : IRequest<EmployeeVm>
    {
    }

    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, EmployeeVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetEmployeesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmployeeVm> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            return new EmployeeVm
            {               

                Lists = await _context.Employees
                    .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Firstname)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
