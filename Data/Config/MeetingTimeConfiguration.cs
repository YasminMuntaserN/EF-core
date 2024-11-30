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
    public class MeetingTimeConfiguration : IEntityTypeConfiguration<MeetingTime>
    {
        public void Configure(EntityTypeBuilder<MeetingTime> builder)
        {
            builder.HasKey(x => x.MeetingTimeID);

            builder.Property(x => x.StartTime).HasColumnType("DateTime2")
                .IsRequired();
          
            builder.Property(x => x.EndTime).HasColumnType("DateTime2")
               .IsRequired();

            builder.ToTable("MeetingTimes");

            //builder.HasData(SeedData.LoadMeetingTimes());
        }
    }
}
