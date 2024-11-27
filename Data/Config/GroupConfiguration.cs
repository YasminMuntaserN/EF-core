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
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(x => x.GroupID);
            builder.Property(x => x.GroupID)
             .ValueGeneratedOnAdd();

            builder.Property(x => x.GroupName).HasColumnType("VARCHAR")
                .HasMaxLength(255).IsRequired();

            builder.Property(x => x.CreationDate).HasColumnType("DateTime")
                .IsRequired();

            builder.Property(x => x.GroupStudentCount).HasColumnType("int")
                 .IsRequired();

            builder.Property(x => x.IsActive).HasColumnType("bit");

         /*   builder.HasOne(x => x.Class)
                   .WithMany(x => x.Groups)
                   .HasForeignKey(x => x.ClassID)
                   .IsRequired();*/

            builder.ToTable("Groups");
        }
    }
}
