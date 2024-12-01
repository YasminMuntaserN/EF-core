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
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(x => x.TeacherID);

            builder.Property(x => x.TeacherID)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Qualification).HasColumnType("VARCHAR")
                .HasMaxLength(255).IsRequired();

            builder.Property(x => x.HireDate).HasColumnType("DateTime2")
                .IsRequired();

            builder.Property(x => x.Salary).HasColumnType("decimal");


            // add one-many relationship between Person and Teachers  
            builder.HasOne(x => x.Person)
                   .WithMany(x => x.Teachers)
                   .HasForeignKey(x => x.PersonID)
                   .IsRequired();

            builder.ToTable("Teachers");
            builder.HasData(SeedData.LoadTeachers());

        }
    }
}
