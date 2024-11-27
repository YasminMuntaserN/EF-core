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
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.StudentID);
            builder.Property(x => x.StudentID)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.CreationDate).HasColumnType("DateTime")
                .IsRequired();


            builder.HasOne(x => x.Person)
                   .WithOne(x => x.Student)
                   .HasForeignKey<Student>(x => x.PersonID)
                   .IsRequired();

            builder.ToTable("Students");

        }
    }
}
