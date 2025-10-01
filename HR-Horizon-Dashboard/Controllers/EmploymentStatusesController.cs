using HR_Horizon.BusinessLogic.Interfaces;
using HR_Horizon.BusinessLogic.Services;
using HR_Horizon.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HR_Horizon_Dashboard.Controllers
{
    public class EmploymentStatusesController : Controller
    {
        private readonly IEmploymentStatusService _employmentStatusRepository;

        public EmploymentStatusesController(IEmploymentStatusService employmentStatusRepository)
        {
            _employmentStatusRepository = employmentStatusRepository;
        }

        // GET: EmploymentStatusesController
        public async Task<ActionResult> Index()
        {
            return View(await _employmentStatusRepository.GetAllAsync());
        }

        // GET: EmploymentStatusesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmploymentStatusesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmploymentStatusesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: EmploymentStatusesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmploymentStatusesController/Edit/5
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

        // GET: EmploymentStatusesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmploymentStatusesController/Delete/5
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
