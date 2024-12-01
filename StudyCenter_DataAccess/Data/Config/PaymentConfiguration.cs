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
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.PaymentID);

            builder.Property(x => x.Amount).HasColumnType("decimal").IsRequired();

            builder.Property(x => x.PaymentDate).HasColumnType("DateTime2")
             .IsRequired();

            // add one-many relationship between Student and Payments  
            builder.HasOne(x => x.Student)
                   .WithMany(x => x.Payments)
                   .HasForeignKey(x => x.StudentID)
                   .IsRequired();

            // add one-many relationship between Group and Payments  
            builder.HasOne(x => x.Group)
                   .WithMany(x => x.Payments)
                   .HasForeignKey(x => x.GroupID)
                   .IsRequired();

            builder.ToTable("Payments");


            //builder.HasData(SeedData.LoadPayments());
        }
    }
}
