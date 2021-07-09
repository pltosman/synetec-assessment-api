using SynetecAssessmentApi.Shared.Entities.Abstract;

namespace SynetecAssessmentApi.Domain.Concrete
{
    public class Employee : EntityBase, IEntity
    {
        public string Fullname { get; set; }
        public string JobTitle { get; set; }
        public int Salary { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

    }
}
