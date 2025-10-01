using HR_Horizon.BusinessLogic.Interfaces;
using HR_Horizon.BusinessLogic.Services;
using HR_Horizon.Core.Entities;
using HR_Horizon_Dashboard.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace HR_Horizon_Dashboard.Controllers
{
    public class UsersController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAccountService _accountService;
        private readonly IEmployeeService _employeeService;
        private readonly RoleManager<IdentityRole> roleManager;

        public UsersController(UserManager<ApplicationUser> userManager,
                               SignInManager<ApplicationUser> signInManager,
                               IAccountService accountService, IEmployeeService employeeService,
                               RoleManager<IdentityRole> _roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _accountService = accountService;
            _employeeService = employeeService;
            roleManager = _roleManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        #region Register
        public IActionResult Register()
        {
            // Send roles to the view using ViewBag
            ViewBag.Roles = roleManager.Roles.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.UserName};
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.Role);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            ViewBag.Roles = roleManager.Roles.ToList();
            return View(model);
        }

        #endregion

        #region Login

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password,isPersistent: false, lockoutOnFailure: false);


                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index),"Home");  
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            return View(model);
        }
        #endregion

        // POST: /Account/Logout
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> AssignUserToEmployee()
        {
            AssignUserViewModel viewModel = new AssignUserViewModel()
            {
                ApplicationUsers = (ICollection<ApplicationUser>) await _accountService.GetUnassigndAccounts(),
                Employees = (ICollection<Employee>) await _employeeService.GetUnassignedEmployees(),
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AssignUserToEmployee(AssignUserViewModel model)
        {
           int respont = await _accountService.AssignEmployeeToUser(model.EmployeeId, model.UserId);
            return View();
        }

    }
}
