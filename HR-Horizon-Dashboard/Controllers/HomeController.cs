using System.Diagnostics;
using HR_Horizon.BusinessLogic.Interfaces;
using HR_Horizon.Core.Entities;
using HR_Horizon.DAL.Contexts;
using HR_Horizon_Dashboard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR_Horizon_Dashboard.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAccountService _accountService;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, IAccountService accountService)
        {
            _logger = logger;
            _userManager = userManager;
            _accountService = accountService;
        }

        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
                return View();

            var userId = _userManager.GetUserId(User);
            ApplicationUser userWithEmployee = await _accountService.GetAccountById(userId);

            //If its a Admin
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction(nameof(EmployeeDashBoard));
            }

            //If its an Employee
            if (User.IsInRole("Employee"))
            {
                if (userWithEmployee?.Employee == null)
                {
                    return RedirectToAction(nameof(NoLinkedEmployee));
                }
                return RedirectToAction(nameof(EmployeeDashBoard));
            }

            //If its a Human Resources
            if (User.IsInRole("Human Resources"))
            {
                return RedirectToAction(nameof(HrDashboard));
            }

            return RedirectToAction(nameof(NoLinkedEmployee));
        }

        public IActionResult NoLinkedEmployee()
        {
            return View();
        }

        public IActionResult EmployeeDashBoard()
        {
            return View();
        }

        public IActionResult AdminDashboard()
        {
            return View();
        }

        public IActionResult HrDashboard()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
