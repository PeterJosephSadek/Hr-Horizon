using HR_Horizon.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HR_Horizon.DAL.Configurations
{
    internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(x => x.FullName)
             .IsRequired()
             .HasColumnType("nvarchar(100)");

            builder.Property(x => x.Email)
              .HasColumnType("VARCHAR(255)");

            builder.Property(x => x.PhoneNumber)
                .HasColumnType("varchar(15)");

            builder.Property(x => x.Address)
                .HasColumnType("nvarchar(255)");

            builder.Property(x => x.Position)
                .HasColumnType("nvarchar(255)");


            builder.Property(x => x.ProfileImageURL)
                .HasColumnType("varchar(500)");

        }
    }
}
