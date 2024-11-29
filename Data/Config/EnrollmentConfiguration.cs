using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using study_center_ef.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study_center_ef.Data.Config
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(x => x.EnrollmentID);

            builder.Property(x => x.EnrollmentDate)
                   .HasColumnType("DateTime2")
                   .IsRequired();

            builder.Property(x => x.DeletionDate)
                   .HasColumnType("DateTime2")
                   .IsRequired();

            builder.Property(x => x.IsActive)
                   .HasColumnType("bit");

            // One-to-many relationship between Group and Enrollment
            builder.HasOne(x => x.Group)
                   .WithMany(x => x.Enrollments)
                   .HasForeignKey(x => x.GroupID)
                   .IsRequired();

            // One-to-many relationship between Student and Enrollment
            builder.HasOne(x => x.Student)
                   .WithMany(x => x.Enrollments)
                   .HasForeignKey(x => x.StudentID)
                   .IsRequired();

            builder.ToTable("Enrollments");
            builder.HasData(SeedData.LoadEnrollments());
        }
    }
}