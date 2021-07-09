using System;
using System.Threading.Tasks;
using SynetecAssessmentApi.Persistence.Abstract;
using SynetecAssessmentApi.Persistence.Concrete.EntityFramework.Contexts;
using SynetecAssessmentApi.Persistence.Concrete.EntityFramework.Repositories;

namespace SynetecAssessmentApi.Persistence.Concrete.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private EfEmployeeRepository _employeeRepository;
     
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IEmployeeRepository Employees => _employeeRepository ?? new EfEmployeeRepository(_context);

     

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
