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
    public class TeacherSubjectConfiguration : IEntityTypeConfiguration<TeacherSubject>
    {
        public void Configure(EntityTypeBuilder<TeacherSubject> builder)
        {
            builder.HasKey(x => x.TeacherSubjectID);

            builder.Property(x => x.IsActive).HasColumnType("bit");


            builder.HasOne(x => x.Teacher)
                         .WithMany(x => x.TeacherSubjects)
                         .HasForeignKey(x => x.TeacherID)
                         .IsRequired();

            builder.HasOne(x => x.GradeLevelSubject)
                    .WithMany(x => x.TeacherSubjects)
                    .HasForeignKey(x => x.GradeLevelSubjectID)
                    .IsRequired();

            builder.ToTable("TeacherSubjects");

            //  builder.HasData(SeedData.LoadTeacherSubjects());
        }
    }
}
