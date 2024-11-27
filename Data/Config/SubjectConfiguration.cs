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
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(x => x.SubjectID);

            builder.Property(x => x.SubjectName).HasColumnType("VARCHAR")
                 .HasMaxLength(255).IsRequired();


            builder.ToTable("Subjects");

          /*  builder.HasMany(s => s.GradeLevels)
                .WithMany(g => g.Subjects)
                .UsingEntity<Dictionary<string, object>>(
                    "GradeLevelSubjects",
                    j => j.HasOne<GradeLevel>().WithMany().HasForeignKey("GradeLevelID"),
                    j => j.HasOne<Subject>().WithMany().HasForeignKey("SubjectID")
                );
          */
            builder.HasData(SeedData.LoadSubjects());
            
        }
    }
}
