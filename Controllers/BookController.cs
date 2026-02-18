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

        public async Task<IActionResult> Create() 
        {
            //ViewBag.Authors = await _context.Authors.ToListAsync();

            var authors = await _context.Authors.ToListAsync();
            var publishingHouses = await _context.PublishingHouses.ToListAsync();

            ViewBag.Authors = new SelectList(_context.Authors, "Id", "Surnames");
            ViewBag.PublishingHouses = new SelectList(_context.PublishingHouses, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            Console.WriteLine("DEBUG");
            Console.WriteLine(book is null ? "<book is null>" : $"AuthorId: {book.AuthorId}");
            Console.WriteLine(book is null ? "<book is null>" : $"PublishingHouseId: {book.PublishingHouseId}");
            Console.WriteLine(book is null ? "<book is null>" : $"Title: {book.Title}");

            if (ModelState.IsValid)
            {
                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            Console.WriteLine("ModelState is invalid. Errors:");
            foreach (var kv in ModelState)
            {
                var key = kv.Key;
                foreach (var err in kv.Value.Errors)
                {
                    Console.WriteLine($" - {key}: {err.ErrorMessage} {(err.Exception != null ? err.Exception.Message : "")}");
                }
            }

            var authors = await _context.Authors.ToListAsync();
            var publishingHouses = await _context.PublishingHouses.ToListAsync();

            ViewBag.Authors = new SelectList(_context.Authors, "Id", "Surnames", book?.AuthorId);
            ViewBag.PublishingHouses = new SelectList(_context.PublishingHouses, "Id", "Name", book?.PublishingHouseId);

            return View(book);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if(book == null)
            {
                return NotFound();
            }

            var authors = await _context.Authors.ToListAsync();
            var publishingHouses = await _context.PublishingHouses.ToListAsync();

            ViewBag.Authors = new SelectList(_context.Authors, "Id", "Surnames", book.AuthorId);
            ViewBag.PublishingHouses = new SelectList(_context.PublishingHouses, "Id", "Name", book.PublishingHouseId);
            return View(book);
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
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

            Console.WriteLine("ModelState is invalid. Errors:");
            foreach (var kv in ModelState)
            {
                var key = kv.Key;
                foreach (var err in kv.Value.Errors)
                {
                    Console.WriteLine($" - {key}: {err.ErrorMessage} {(err.Exception != null ? err.Exception.Message : "")}");
                }
            }

            var authors = await _context.Authors.ToListAsync();
            var publishingHouses = await _context.PublishingHouses.ToListAsync();
            ViewBag.Authors = new SelectList(_context.Authors, "Id", "Surnames", book.AuthorId);
            ViewBag.PublishingHouses = new SelectList(_context.PublishingHouses, "Id", "Name", book.PublishingHouseId);
            return View(book);
        }
    }
}
