using HR_Horizon.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HR_Horizon.DAL.Contexts
{
    public class ApplicationDbContext : IdentityDbContext    
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
       {

       }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           base.OnModelCreating(modelBuilder);

           // Global Query Filter for IsDeleted
           modelBuilder.Entity<Employee>().HasQueryFilter(e => !e.IsDeleted);
           modelBuilder.Entity<Department>().HasQueryFilter(e => !e.IsDeleted);
           modelBuilder.Entity<EmploymentStatus>().HasQueryFilter(e => !e.IsDeleted);
           modelBuilder.Entity<EmploymentType>().HasQueryFilter(e => !e.IsDeleted);


            modelBuilder.Entity<Employee>()
                .Navigation(e => e.Department)
                .AutoInclude();

            modelBuilder.Entity<Employee>()
                .Navigation(e => e.EmploymentStatus)
                .AutoInclude();

            modelBuilder.Entity<Employee>()
                .Navigation(e => e.EmploymentType)
                .AutoInclude();

            modelBuilder.Entity<PermissionRequest>()
                .Navigation(e => e.Employee)
                .AutoInclude();

            modelBuilder.Entity<PermissionRequest>()
                .Navigation(e => e.RequestStatus)
                .AutoInclude();


            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                // Make EmployeeId nullable in the database
                entity.Property(u => u.EmployeeId)
                    .IsRequired(false); // This allows NULL in the database

                // Configure the relationship as optional (allowing null)
                entity.HasOne(u => u.Employee)
                    .WithMany() // If Employee has no collection of ApplicationUsers, use WithMany() without parameter
                    .HasForeignKey(u => u.EmployeeId)
                    .IsRequired(false) // This makes the relationship optional
                    .OnDelete(DeleteBehavior.SetNull); // Optional: Set delete behavior

                entity.Navigation(e => e.Employee)
                .AutoInclude();

            });

            modelBuilder.Entity<PermissionRequest>(entity => {

                entity.Navigation(e => e.RequestStatus)
                .AutoInclude();

                // Configure the relationship as optional (allowing null)
                entity.HasOne(u => u.Employee)
                    .WithMany() // If Employee has no collection of ApplicationUsers, use WithMany() without parameter
                    .HasForeignKey(u => u.EmployeeId)
                    .IsRequired(true)
                    .OnDelete(DeleteBehavior.ClientCascade);
            });
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmploymentStatus> EmploymentStatuses { get; set; }
        public DbSet<EmploymentType> EmploymentTypes { get; set; }
        public DbSet<RequestStatus> RequestStatuses { get; set; }
        public DbSet<PermissionRequest> PermissionRequests { get; set; }




    }
}
