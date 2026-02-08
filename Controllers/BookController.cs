using Microsoft.AspNetCore.Mvc;
using ClassicLibraryMVC.Models;

namespace ClassicLibraryMVC.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Overview()
        {
            var books = new List<Book>
            {
                new Book { Id = 0, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", PublicationYear = 1925 },
                new Book { Id = 1, Title = "Quo Vadis", Author = "Henryk Sienkiewicz", PublicationYear = 1905},
                new Book { Id = 2, Title = "Ice", Author = "Jacek Dukaj", PublicationYear=2007}
            };



            return View(books);
        }

        public IActionResult Details(int id)
        {
            var books = new List<Book>
            {
                new Book { Id = 0, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", PublicationYear = 1925 },
                new Book { Id = 1, Title = "Quo Vadis", Author = "Henryk Sienkiewicz", PublicationYear = 1905},
                new Book { Id = 2, Title = "Ice", Author = "Jacek Dukaj", PublicationYear=2007}
            };

            var book = books.FirstOrDefault(books => books.Id == id);

            return View(book);
        }
    }
}
