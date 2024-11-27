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
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.PersonID);
            builder.Property(x => x.PersonID)
             .ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName).HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();

            builder.Property(x => x.SecondName).HasColumnType("VARCHAR")
                .HasMaxLength(50).IsRequired();

            builder.Property(x => x.ThirdName).HasColumnType("VARCHAR")
               .HasMaxLength(50);

            builder.Property(x => x.LastName).HasColumnType("VARCHAR")
                 .HasMaxLength(50).IsRequired();

            builder.Property(x => x.Email).HasColumnType("VARCHAR")
                  .HasMaxLength(255).IsRequired();

            builder.Property(x => x.PhoneNumber).HasColumnType("VARCHAR")
              .HasMaxLength(255);

            builder.Property(x => x.Address).HasColumnType("VARCHAR")
                 .HasMaxLength(255).IsRequired();
          
            builder.Property(x => x.DateOfBirth).HasColumnType("DateTime")
                .IsRequired();

            builder.Property(x => x.Gender).HasColumnType("TINYINT").IsRequired();



            builder.ToTable("People");
        }
    }
}
