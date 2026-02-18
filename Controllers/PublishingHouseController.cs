using Microsoft.AspNetCore.Mvc;
using ClassicLibraryMVC.Models;
using Microsoft.EntityFrameworkCore;
using ClassicLibraryMVC.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClassicLibraryMVC.Controllers
{
    public class PublishingHouseController : Controller
    {

        private readonly LibraryContext _context;

        public PublishingHouseController(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var publishingHouses = await _context.PublishingHouses.ToListAsync();
            return View(publishingHouses);
        }

        public async Task<IActionResult> Details(int id)
        {
            var publishingHouse = await _context.PublishingHouses.Include(p => p.Books).FirstOrDefaultAsync(b => b.Id == id);

            return View(publishingHouse);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PublishingHouse publishingHouse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publishingHouse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(publishingHouse);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var publishingHouse = await _context.PublishingHouses.FindAsync(id);

            if (publishingHouse == null)
            {
                return NotFound();
            }

            return View(publishingHouse);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PublishingHouse publishingHouse)
        {
            if (id != publishingHouse.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publishingHouse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublishingHouseExists(publishingHouse.Id))
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
            return View(publishingHouse);
        }

        private bool PublishingHouseExists(int id)
        {
            return _context.PublishingHouses.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Delete (int id)
        {
            var publishingHouse = await _context.PublishingHouses.FindAsync(id);

            if (publishingHouse == null)
            {
                return NotFound();
            }

            return View(publishingHouse);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publishingHouse = await _context.PublishingHouses.FindAsync(id);

            if(publishingHouse == null)
            {
                return NotFound();
            }

            _context.PublishingHouses.Remove(publishingHouse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

