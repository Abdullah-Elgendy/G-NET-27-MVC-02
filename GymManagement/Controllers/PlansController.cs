using GymManagement.DAL.Repositories.Classes;
using GymManagement.DAL.Repositories.Interfaces;
using GymManagement.DAL.Data.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Controllers
{
    
    public class PlansController : Controller
    {
        private readonly IPlanRepository _planRepo;
        
        public PlansController(IPlanRepository planRepo)
        {
            _planRepo = planRepo;
        }

        //Index
        // GET: BaseUrl/Plans/Index -> Index view -> List of all plans
        public async Task<IActionResult> Index()
        {
            var plans = await _planRepo.GetAllAsync();

            return View(plans);
        }


        // Details
        // GET: BaseUrl/Plans/Details/{Id}-> Detail view -> Details about plan
        public async Task<IActionResult> Details(int Id)
        {
            var plan = await _planRepo.GetByIdAsync(Id);

            if (plan is null)
            return RedirectToAction(nameof(Index));
            else
            return View(plan);
        }
    }
}
