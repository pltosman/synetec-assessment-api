using System;
using SyntecAssessmentApi.Services.Abstract;

namespace SyntecAssessmentApi.Services.Concrete
{
    public class Calculator : ICalculator
    {
        public int getBonusAllocation(int salary, int totalSalary, int bonusPoolAmount)
        {

            decimal bonusPercentage = salary / totalSalary;
            int bonusAllocation = (int)(bonusPercentage * bonusPoolAmount);

            return bonusAllocation;
        }
    }
}
