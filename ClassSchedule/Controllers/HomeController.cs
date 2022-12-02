using Microsoft.AspNetCore.Mvc;
using LibraryOrganizer.Models;

namespace LibraryOrganizer.Controllers
{
    public class HomeController : Controller
    {
        private LibraryOrganizerUnitOfWork<Title> titles { get; set; }

        public HomeController(LibraryContext ctx) {
            titles = new LibraryOrganizerUnitOfWork<Title>(ctx);
        }

        public ViewResult Index(int id)
        {
            // options for Classes query
            var bookOptions = new QueryOptions<Title> {
                Includes = "Author"
            };
            return View(titles.Titles.List(bookOptions));
        }

        public ViewResult AboutMe()
        {
            return View();
        }
    }
}
