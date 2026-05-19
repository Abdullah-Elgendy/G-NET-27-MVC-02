using GymManagement.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Controllers
{
    public class PlansController : Controller
    {
        private readonly GymDbContext _context = new GymDbContext();

        //Index
        // GET: BaseUrl/Plans/Index -> Index view -> List of all plans
        public async Task<IActionResult> Index()
        {
            var plans = await _context.Plans.ToListAsync();

            return View(plans);
        }


        // Details
        // GET: BaseUrl/Plans/Details/{Id}-> Detail view -> Details about plan
        public async Task<IActionResult> Details(int Id)
        {
            var plan = await _context.Plans.FirstOrDefaultAsync(P => P.Id == Id);

            if (plan is null)
            return RedirectToAction(nameof(Index));
            
            return View(plan);
        }
    }
}
