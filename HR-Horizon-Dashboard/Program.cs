using HR_Horizon.BusinessLogic.Interfaces;
using HR_Horizon.BusinessLogic.Services;
using HR_Horizon.Core.Entities;
using HR_Horizon.DAL.Contexts;
using HR_Horizon.DAL.Interfaces;
using HR_Horizon.DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HR_Horizon_Dashboard
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            // Add DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            // Register repositories
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IEmploymentTypeRepository, EmploymentTypeRepository>();
            builder.Services.AddScoped<IEmploymentStatusRepository, EmploymentStatusRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();



            // Register business logic services
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmploymentTypeService, EmploymentTypeService>();
            builder.Services.AddScoped<IEmploymentStatusService, EmploymentStatusService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IPermissionService, PermissionRequestService>();



            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

            }).AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();



            // Configure Identity with custom login path
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Users/Login"; // Your custom login path
                options.AccessDeniedPath = "/Users/AccessDenied"; // Custom access denied path
                options.LogoutPath = "/Users/Logout"; // Custom logout path
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Add authentication and authorization middleware
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
