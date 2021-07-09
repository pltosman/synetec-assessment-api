using System.Collections.Generic;
using SynetecAssessmentApi.Shared.Entities.Abstract;


namespace SynetecAssessmentApi.Domain.Concrete
{
    public class Department : EntityBase, IEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

       
    }
}
