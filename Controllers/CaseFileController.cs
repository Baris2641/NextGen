using efCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace efCoreApp.Controllers
{
    public class CaseFileController : Controller
    {
        private readonly CaseFileContext _context;
        public CaseFileController(CaseFileContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var file = await _context.CaseFiles.ToListAsync();
            return View(file);
        }

        public async Task<IActionResult> Create()
        {
            var caseFiles = await _context.CaseFiles.ToListAsync();
            var lawyers = await _context.Lawyers.ToListAsync();

            if (caseFiles == null || lawyers == null)
            {
                // Hata mesajını loglayabiliriz veya uygun bir hata sayfasına yönlendirebiliriz.
                throw new NullReferenceException("CaseFiles or Lawyers list is null");
            }

            ViewBag.CaseFiles = new SelectList(caseFiles, "Id", "CaseFileName");
            ViewBag.Lawyers = new SelectList(lawyers, "LawyerId", "LawyerFullName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CaseFile caseFile)
        {
            _context.CaseFiles.Add(caseFile);
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

            var caseFile = await _context.CaseFiles.FirstOrDefaultAsync(caseFile => caseFile.LawyerId == id);
            if (caseFile == null)
            {
                return NotFound();
            }

            return View(caseFile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CaseFile model)
        {
            if (id != model.Id)
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
                    if (!_context.CaseFiles.Any(caseFile => caseFile.Id == model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

    }
}