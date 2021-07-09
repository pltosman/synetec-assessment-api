using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Domain.Concrete;

namespace SynetecAssessmentApi.Persistence.Concrete.EntityFramework.EntityConfiguration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).ValueGeneratedNever();
            builder.ToTable("Departments");
        }
    }
}
