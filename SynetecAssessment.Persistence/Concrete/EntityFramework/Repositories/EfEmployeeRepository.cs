using System;
using System.Threading.Tasks;
using SynetecAssessmentApi.Domain.Concrete;
using SynetecAssessmentApi.Persistence.Abstract;
using SynetecAssessmentApi.Persistence.Concrete.EntityFramework.Contexts;
using SynetecAssessmentApi.Shared.Data.Concrete.EntityFramework;
using System.Linq;
using SynetecAssessmentApi.Shared.Utilities.Results.Concrete;

namespace SynetecAssessmentApi.Persistence.Concrete.EntityFramework.Repositories
{
    public class EfEmployeeRepository: EfEntityRepositoryBase<Employee>, IEmployeeRepository
    {
        public EfEmployeeRepository(AppDbContext context) : base(context)
        {

        }


         public async Task<Int32> GetCompanyTotalSalary()
        {
            //get the total salary budget for the company
            var employees = await GetAllAsync();
            int totalSalary = employees.Sum(z => z.Salary);
            //calculate the bonus allocation for the employee

            return totalSalary;
        }

    }
   
}
