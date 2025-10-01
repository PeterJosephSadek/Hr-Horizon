using HR_Horizon.BusinessLogic.Interfaces;
using HR_Horizon.Core.Dtos;
using HR_Horizon.Core.Entities;
using HR_Horizon_Dashboard.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HR_Horizon_Dashboard.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<DepartmentsController> _logger;

        public DepartmentsController(IDepartmentService departmentService, ILogger<DepartmentsController> logger)
        {
            _departmentService = departmentService;
            _logger = logger;
        }

        // GET: DepartmentController
        public async Task<ActionResult> Index()
        {
           var Department = await _departmentService.GetAllAsync();
            return View(Department);
        }

        // GET: DepartmentController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _departmentService.GetByIdAsync(id));
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateDepartmentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DepartmentDto departmentDto = new DepartmentDto()
                    {
                        Name = viewModel.Name,
                    };

                    int respond = await _departmentService.AddAsync(departmentDto, User?.Identity?.Name ?? "Anonymous");
                    if (respond >= 0)
                    {
                        _logger.LogInformation($"User : {User?.Identity?.Name ?? "Anonymous"} Has Successfully Added department With ID {respond}");
                    }
                    else 
                    {
                        _logger.LogWarning($"Respond Number : {respond}");
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
