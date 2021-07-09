using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SynetecAssessmentApi.Domain.Dtos;
using SynetecAssessmentApi.Shared.Utilities.Results.Concrete;

namespace SyntecAssessmentApi.Services.Abstract
{
    public interface IBonusPoolService
    {
        Task<CommandResult> GetEmployeesAsync();
        Task<CommandResult> CalculateAsync(int bonusPoolAmount, int selectedEmployeeId);
       
    }
}
