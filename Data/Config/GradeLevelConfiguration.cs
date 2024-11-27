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
    public class GradeLevelConfiguration : IEntityTypeConfiguration<GradeLevel>
    {
        public void Configure(EntityTypeBuilder<GradeLevel> builder)
        {
            builder.HasKey(x => x.GradeLevelID);

            builder.Property(x => x.GradeLevelName).HasColumnType("VARCHAR")
                 .HasMaxLength(255).IsRequired();


            builder.ToTable("GradeLevels");
            builder.HasData(SeedData.LoadGradeLevels());
        }
    }
}
