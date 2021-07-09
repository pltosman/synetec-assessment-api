using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using SynetecAssessmentApi.Domain.Concrete;
using SynetecAssessmentApi.Domain.Dtos;
using SynetecAssessmentApi.Persistence.Abstract;
using SynetecAssessmentApi.Shared.Utilities.Results.Concrete;
using SyntecAssessmentApi.Services.Abstract;
using SyntecAssessmentApi.Services.Concrete;
using Xunit;

namespace SynetecAssessmentApi.Tests
{
    public class CalculationTests
    {
        private readonly Calculator _sut;

        public CalculationTests()
        {
            _sut = new Calculator();
        }

        [Fact]
        public void ReturnsBonusAllocationAsync()
        {
            const int Salary = 95000;
            const int TotalSalary = 654750;
            const int BonusPoolAmount = 54700;
            const int ExpectedResult = 7936;

            var result = _sut.getBonusAllocation(Salary, TotalSalary, BonusPoolAmount);

            Assert.Equal(ExpectedResult, result);

        }


        [Fact]
        public void ReturnsZeroIfTotalSalaryZero()
        {
            const int Salary = 95000;
            const int TotalSalary = 0;
            const int BonusPoolAmount = 54700;
            const int ExpectedResult = 0;


            var result = _sut.getBonusAllocation(Salary, TotalSalary, BonusPoolAmount);

            Assert.Equal(ExpectedResult, result);

        }

    }
}
