using HR_Horizon.BusinessLogic.Interfaces;
using HR_Horizon.Core.Dtos;
using HR_Horizon.Core.Entities;
using HR_Horizon_Dashboard.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HR_Horizon_Dashboard.Controllers
{
    public class PermissionRequestsController : Controller
    {

        private readonly IPermissionService _permissionService;
        private readonly UserManager<ApplicationUser> _userManager;

        public PermissionRequestsController(IPermissionService permissionService, UserManager<ApplicationUser> userManager)
        {

            _permissionService = permissionService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var reqs = await _permissionService.GetAllAsync();
            return View(reqs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PermissionRequestViewModel model)
        {
            // Get the logged-in ApplicationUser  
            var appUser = await _userManager.GetUserAsync(User);

            if (appUser == null)
            {
                return Unauthorized();
            }

            if (!appUser.EmployeeId.HasValue)
            {
                return BadRequest("EmployeeId is required for the logged-in user.");
            }

            PermissionRequestDto permissionRequestDto = new PermissionRequestDto()
            {
                Comment = model.Comment,
                EmployeeId = appUser.EmployeeId.Value,
                RequestedDate = model.RequestedDate,
                TimeFrom = model.TimeFrom,
                TimeTo = model.TimeTo,
            };

            await _permissionService.AddAsync(permissionRequestDto, appUser.UserName);

            return View();
        }
    }
}
