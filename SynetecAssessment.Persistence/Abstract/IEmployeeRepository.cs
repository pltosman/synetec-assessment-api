using System;
using System.Threading.Tasks;
using SynetecAssessmentApi.Domain.Concrete;
using SynetecAssessmentApi.Shared.Data.Abstract;
using SynetecAssessmentApi.Shared.Utilities.Results.Concrete;

namespace SynetecAssessmentApi.Persistence.Abstract
{
    public interface IEmployeeRepository : IEntityRepository<Employee>
    {
        Task<Int32> GetCompanyTotalSalary();
    }
}
