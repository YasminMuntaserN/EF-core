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
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(x => x.SubjectID);

            builder.Property(x => x.SubjectName).HasColumnType("VARCHAR")
                 .HasMaxLength(255).IsRequired();

            //add one-many relationship between GradeLevel and Subjects
            builder.HasOne(x => x.GradeLevel)
                         .WithMany(x => x.Subjects)
                         .HasForeignKey(x => x.GradeLevelId)
                         .IsRequired();


            builder.ToTable("Subjects");

            builder.HasData(SeedData.LoadSubjects());

        }
    }
}
