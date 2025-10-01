using HR_Horizon.BusinessLogic.Interfaces;
using HR_Horizon.BusinessLogic.Services;
using HR_Horizon.Core.Dtos;
using HR_Horizon_Dashboard.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HR_Horizon_Dashboard.Controllers
{
    public class EmploymentTypesController : Controller
    {
        private readonly IEmploymentTypeService _employmentTypeServiceService;
        private readonly ILogger<EmploymentTypesController> _logger;

        public EmploymentTypesController(IEmploymentTypeService IEmploymentTypeService, ILogger<EmploymentTypesController> logger)
        {
            _employmentTypeServiceService = IEmploymentTypeService;
            _logger = logger;
        }


        // GET: EmploymentTypesController
        public async Task<ActionResult> Index()
        {
            return View(await _employmentTypeServiceService.GetAllAsync());
        }

        // GET: EmploymentTypesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmploymentTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmploymentTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateEmploymentTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    EmploymentTypeDto employmentTypeDto = new EmploymentTypeDto()
                    {
                        Name = viewModel.Name,
                    };

                    int respond = await _employmentTypeServiceService.AddAsync(employmentTypeDto, User?.Identity?.Name ?? "Anonymous");
                    if (respond >= 0)
                    {
                        _logger.LogInformation($"User : {User?.Identity?.Name ?? "Anonymous"} Has Successfully Added Employment Type With ID {respond}");
                    }
                    else
                    {
                        _logger.LogWarning($"Respond Number : {respond}");
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(viewModel);
                }
            }
            else
            {
                return View(viewModel);
            }
        }

        // GET: EmploymentTypesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmploymentTypesController/Edit/5
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

        // GET: EmploymentTypesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmploymentTypesController/Delete/5
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
