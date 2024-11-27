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
    public class GradeLevelSubjectConfiguration : IEntityTypeConfiguration<GradeLevelSubject>
    {
        public void Configure(EntityTypeBuilder<GradeLevelSubject> builder)
        {
            builder.HasKey(x => x.GradeLevelSubjectID);
            builder.Property(x => x.GradeLevelSubjectID)
            .ValueGeneratedOnAdd();

            builder.Property(x => x.Title).HasColumnType("VARCHAR")
                 .HasMaxLength(255).IsRequired();
           
            builder.Property(x => x.Fees).HasColumnType("int");

            builder.ToTable("GradeLevelSubjects");

        }
    }
}
