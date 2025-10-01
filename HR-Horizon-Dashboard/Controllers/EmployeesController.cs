using HR_Horizon.BusinessLogic.Interfaces;
using HR_Horizon.Core.Dtos;
using HR_Horizon.Core.Entities;
using HR_Horizon_Dashboard.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HR_Horizon_Dashboard.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmploymentStatusService _employmentStatusService;
        private readonly IDepartmentService _departmentService;
        private readonly IEmploymentTypeService _employmentTypeService;
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(IEmploymentStatusService employmentStatusService, 
            IDepartmentService departmentService, 
            IEmploymentTypeService employmentTypeService,
            IEmployeeService employeeService,
            ILogger<EmployeesController> logger)
        {
            _employmentStatusService = employmentStatusService;
            _departmentService = departmentService;
            _employmentTypeService = employmentTypeService;
            _employeeService = employeeService;
            _logger = logger;
        }

        // Fix for CS1061, CS0266, and CS8629
        public ActionResult Index()
        {
            var employeesTask = _employeeService.GetAllAsync();
            var employees = employeesTask.Result;
            var ViewModels = employees.Select(E => new IndexEmployeesDto()
            {
                DepartmentId = E.DepartmentId,
                FullName = E.FullName,
                Email = E.Email,
                IsActive = E.IsActive,
                DepartmentName = E.Department.Name,
                Id = E.Id,
                Type = E.EmploymentType.Name,
                Joined = E.JoiningDate.HasValue ? (DateOnly)E.JoiningDate : default,
                ManagerId = E.ManagerId,
                ManagerName = E.Manager?.FullName, 
                ProfileImageURL = E.ProfileImageURL,
            });

            return View(ViewModels);
        }

        // GET: EmployeesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var emp = await _employeeService.GetByIdAsync(id);

            if (emp == null)
            {
                return View("Error");
            }
            return View(emp);
        }

        // GET: EmployeesController/Create
        public async Task<ActionResult> Create()
        {
            var employmentStatuses = await _employmentStatusService.GetAllAsync();
            var departments = await _departmentService.GetAllAsync();
            var employmentTypes = await _employmentTypeService.GetAllAsync();
            var managers = await _employeeService.GetManagers();

            var viewModel = new CreateEmployeeViewModelcs()
            {
                Departments = departments.Select(d => new SelectListItem(d.Name,d.Id.ToString())),
                EmploymentStatauses = employmentStatuses.Select(es => new SelectListItem(es.Name, es.Id.ToString())),
                EmploymentTypes = employmentTypes.Select(es => new SelectListItem(es.Name, es.Id.ToString())),
                Managers = managers.Select(es => new SelectListItem(es.FullName, es.Id.ToString()))


            };

            return View(viewModel);
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateEmployeeViewModelcs createEmployeeView)
        {
            if (ModelState.IsValid)
            {
                var employee = new CreateEmployeeDto()
                {
                    Address = createEmployeeView.Address,
                    DepartmentId = createEmployeeView.DepartmentId,
                    Email = createEmployeeView.Email,
                    EmploymentStatusId = createEmployeeView.EmploymentStatusId,
                    EmploymentTypeId = createEmployeeView.EmploymentTypeId,
                    FullName = createEmployeeView.FullName,
                    Gender = (char)createEmployeeView.Gender,
                    JoiningDate = createEmployeeView.JoiningDate,
                    ManagerId = createEmployeeView.ManagerId,
                    PhoneNumber = createEmployeeView.PhoneNumber,
                    Position = createEmployeeView.Position,
                    ProfileImageURL = createEmployeeView.ProfileImageURL,

                };

                int respond = await _employeeService.AddAsync(employee, User?.Identity?.Name ?? "Anuminums");

                if (respond >= 0)
                {
                    _logger.LogInformation($"User : {User?.Identity?.Name ?? "Anonymous"} Has Successfully Added Employee With ID {respond}");
                }
                else
                {
                    _logger.LogWarning($"Respond Number : {respond}");
                }
                return RedirectToAction(nameof(Index));

            }
            else
            {
                var employmentStatuses = await _employmentStatusService.GetAllAsync();
                var departments = await _departmentService.GetAllAsync();
                var employmentTypes = await _employmentTypeService.GetAllAsync();
                var managers = await _employeeService.GetManagers();


                createEmployeeView.Departments = departments.Select(d => new SelectListItem(d.Name, d.Id.ToString()));
                createEmployeeView.EmploymentStatauses = employmentStatuses.Select(es => new SelectListItem(es.Name, es.Id.ToString()));
                createEmployeeView.EmploymentTypes = employmentTypes.Select(es => new SelectListItem(es.Name, es.Id.ToString()));
                createEmployeeView.Managers = managers.Select(es => new SelectListItem(es.FullName, es.Id.ToString()));

                return View(createEmployeeView);
            }

        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeesController/Edit/5
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

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeesController/Delete/5
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
