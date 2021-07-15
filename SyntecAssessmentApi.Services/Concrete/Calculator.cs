using System;
using SyntecAssessmentApi.Services.Abstract;

namespace SyntecAssessmentApi.Services.Concrete
{
    public class Calculator : ICalculator
    {
        public int getBonusAllocation(int salary, int totalSalary, int bonusPoolAmount)
        {

            if(totalSalary== 0)
            {
                return 0;
            }

            decimal bonusPercentage = (decimal)salary / (decimal)totalSalary;
            int bonusAllocation = (int)(bonusPercentage * bonusPoolAmount);

            return bonusAllocation;
        }
    }
}
