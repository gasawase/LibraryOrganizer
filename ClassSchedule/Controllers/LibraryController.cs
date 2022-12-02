using Microsoft.AspNetCore.Mvc;
using LibraryOrganizer.Models;

namespace LibraryOrganizer.Controllers
{
    public class LibraryController : Controller
    {
        private LibraryOrganizerUnitOfWork<Title> titles { get; set; }

        public LibraryController(LibraryContext ctx) {
            titles = new LibraryOrganizerUnitOfWork<Title>(ctx);
        }

        public ViewResult LibraryIndex()
        {
            // options for Classes query
            var bookOptions = new QueryOptions<Title> {
                Includes = "Author"
            };
            return View(titles.Titles.List(bookOptions));
        }

        public ViewResult CreateLibrary()
        {
            return View();
        }
    }
}
