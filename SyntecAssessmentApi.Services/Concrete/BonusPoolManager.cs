using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SynetecAssessmentApi.Domain.Dtos;
using SynetecAssessmentApi.Persistence.Abstract;
using SyntecAssessmentApi.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.Domain.Concrete;
using System.Linq;
using SynetecAssessmentApi.Shared.Utilities.Results.Concrete;
using System;
using Microsoft.Extensions.Logging;

namespace SyntecAssessmentApi.Services.Concrete
{
    public class BonusPoolManager :IBonusPoolService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<BonusPoolManager> _logger;
        private readonly ICalculator _calculator;


        public BonusPoolManager(IUnitOfWork unitOfWork, IMapper mapper, ILogger<BonusPoolManager> logger, ICalculator calculator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _calculator = calculator;
        }

        public async Task<CommandResult> GetEmployeesAsync() { 
            IEnumerable<Employee> employees = await _unitOfWork.Employees.GetAllAsync(null,e => e.Department);

          var result=  _mapper.Map<IEnumerable<EmployeeDto>>(employees);
           

            return CommandResult.GetSuccess(result);
        }

        public async Task<CommandResult> CalculateAsync(int bonusPoolAmount, int selectedEmployeeId)
    {
            
            //load the details of the selected employee using the Id
            Employee employee = await _unitOfWork.Employees.GetAsync(item => item.Id == selectedEmployeeId, e => e.Department);

            if (employee == null)
            {                
                _logger.LogInformation("Unable to find a employee with Id:{Id}", selectedEmployeeId);
                return CommandResult.GetError($"Unable to find a employee with Id:{selectedEmployeeId}");
            }

            //get the total salary budget for the company

            var totalSalary = await _unitOfWork.Employees.GetCompanyTotalSalary();


            if (totalSalary == 0)
            {
                _logger.LogInformation("Could not reach totalSalary");
                return CommandResult.GetError("Could not reach totalSalar");
            }


            var bonus =  _calculator.getBonusAllocation(employee.Salary, totalSalary, bonusPoolAmount);
       

            var bonusPoolCalculatorDto = new BonusPoolCalculatorResultDto
            {
                Employee = _mapper.Map<EmployeeDto>(employee),
                Amount = bonus
            };

          return  CommandResult.GetSuccess(bonusPoolCalculatorDto);

        }

    }
}
