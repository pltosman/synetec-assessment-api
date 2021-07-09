using System;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Persistence.Abstract
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employees { get; }

        Task<int> SaveAsync();
    }
}
