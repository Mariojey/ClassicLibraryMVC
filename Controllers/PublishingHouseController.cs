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
    }
}

