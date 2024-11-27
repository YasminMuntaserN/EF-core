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
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(x => x.ClassID);

            builder.Property(x => x.ClassName).HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();

            builder.Property(x => x.Description).HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();


            builder.Property(x => x.Capacity).HasColumnType("TINYINT").IsRequired();

            builder.ToTable("Classes");
            builder.HasData(SeedData.LoadClasses());
        }
    }
}
