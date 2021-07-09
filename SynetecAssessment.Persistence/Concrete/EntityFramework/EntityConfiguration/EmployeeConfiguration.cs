﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Domain.Concrete;

namespace SynetecAssessmentApi.Persistence.Concrete.EntityFramework.EntityConfiguration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.ToTable("Employees");

            builder
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(d => d.DepartmentId);
        }
    }
}
