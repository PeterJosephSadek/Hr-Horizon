using HR_Horizon.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Horizon.DAL.Configurations
{
    internal class EmploymentStatusConfiguration : IEntityTypeConfiguration<EmploymentStatus>
    {

        public void Configure(EntityTypeBuilder<EmploymentStatus> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("nvarchar(100)");

            builder.HasMany(x => x.Employees)
                    .WithOne(x => x.EmploymentStatus)
                    .HasForeignKey(x => x.EmploymentStatusId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
