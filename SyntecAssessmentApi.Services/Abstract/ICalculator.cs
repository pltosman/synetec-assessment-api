using System;
namespace SyntecAssessmentApi.Services.Abstract
{
    public interface ICalculator
    {
        int getBonusAllocation(int salary, int totalSalary, int bonusPoolAmount);
    }
}
