using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using study_center_ef.Entities.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study_center_ef.DataAccess.Data.Config.views
{
    public class StudentDetailConfiguration : IEntityTypeConfiguration<StudentDetail>
    {
        public void Configure(EntityTypeBuilder<StudentDetail> builder)
        {
            builder.HasNoKey();

            builder.ToView("StudentsDetails");

        }
    }
}
