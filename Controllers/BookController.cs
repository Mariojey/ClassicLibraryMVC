using Microsoft.AspNetCore.Mvc;
using ClassicLibraryMVC.Models;
using Microsoft.EntityFrameworkCore;
using ClassicLibraryMVC.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClassicLibraryMVC.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryContext _context;

        public BookController(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _context.Books.ToListAsync();
            return View(books);
        }

        public async Task<IActionResult> Details(int id)
        {
            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.PublishingHouse)
                .FirstOrDefaultAsync(b => b.Id == id);

            return View(book);
        }

        public IActionResult Create() 
        {
            //ViewBag.Authors = await _context.Authors.ToListAsync();

            ViewBag.Authors = new SelectList(_context.Authors, "Id", "Surnames", "Names");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Authors = new SelectList(_context.Authors, "Id", "Surnames", "Names", book.AuthorId.ToString());
            return View(book);
        }
    }
}
