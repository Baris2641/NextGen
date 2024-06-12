using efCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efCoreApp.Controllers
{
    public class LawyerController : Controller
    {
        private readonly CaseFileContext _context;
        public LawyerController(CaseFileContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<ActionResult> Index()
        {
            var lawyer = await _context.Lawyers.ToListAsync();
            return View(lawyer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Lawyer lawyer)
        {
            _context.Lawyers.Add(lawyer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lawyer = await _context.Lawyers.FirstOrDefaultAsync(lawyer => lawyer.LawyerId == id);
            if (lawyer == null)
            {
                return NotFound();
            }

            return View(lawyer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Lawyer model)


        {
            if (id != model.LawyerId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Users.Any(user => user.UserId == model.LawyerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lawyer = await _context.Lawyers.FindAsync(id);
            if (lawyer == null)
            {
                return NotFound();
            }

            return View(lawyer);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var lawyer = await _context.Lawyers.FindAsync(id);
            if (lawyer == null)
            {
                return NotFound();
            }
            _context.Lawyers.Remove(lawyer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}