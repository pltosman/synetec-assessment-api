using System;
using FluentValidation;
using SynetecAssessmentApi.Domain.Dtos;

namespace SyntecAssessmentApi.Services.Validations
{
    public class EmployeePoolAmountValidatior : AbstractValidator<CalculateBonusDto>
    {
        public EmployeePoolAmountValidatior()
        {
            RuleFor(v => v.SelectedEmployeeId).NotEmpty();
            RuleFor(v => v.TotalBonusPoolAmount).NotEmpty();
        }
    }
}
