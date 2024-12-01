using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using study_center_ef.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study_center_ef.DataAccess.Data.Config
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.StudentID);
            builder.Property(x => x.StudentID)
                   .ValueGeneratedOnAdd();


            // add one-many relationship between Person and Students  
            builder.HasOne(x => x.Person)
                   .WithMany(x => x.Students)
                   .HasForeignKey(x => x.PersonID)
                   .IsRequired();

            // add one-many relationship between GradeLevel and Students  
            builder.HasOne(x => x.GradeLevel)
                   .WithMany(x => x.Students)
                   .HasForeignKey(x => x.GradeLevelID)
                   .IsRequired();

            builder.ToTable("Students");
            builder.HasData(SeedData.LoadStudents());


        }
    }
}
