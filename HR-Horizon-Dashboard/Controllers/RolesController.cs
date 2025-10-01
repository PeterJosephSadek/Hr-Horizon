using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HR_Horizon_Dashboard.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }


        public IActionResult Index()
        {
            IQueryable<IdentityRole> roles = _roleManager.Roles; // list of all roles
            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: /Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            if (string.IsNullOrWhiteSpace(role.Name))
            {
                ModelState.AddModelError("", "Role name cannot be empty.");
                return View();
            }

            var roleExists = await _roleManager.RoleExistsAsync(role.Name);
            if (roleExists)
            {
                ModelState.AddModelError("", "Role already exists.");
                return View();
            }

            var result = await _roleManager.CreateAsync(new IdentityRole(role.Name));
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View();
        }

    }
}
