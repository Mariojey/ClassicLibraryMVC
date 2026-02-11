using Microsoft.AspNetCore.Mvc;
using ClassicLibraryMVC.Models;
using Microsoft.EntityFrameworkCore;
using ClassicLibraryMVC.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClassicLibraryMVC.Controllers
{
    public class AuthorController : Controller
    {

        private readonly LibraryContext _context;

        public AuthorController(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _context.Authors.ToListAsync();
            return View(authors);
        }

        public async Task<IActionResult> Details(int id)
        {
            var author = await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);

            return View(author);
        }
    }
}
