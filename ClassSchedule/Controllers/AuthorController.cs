using Microsoft.AspNetCore.Mvc;
using LibraryOrganizer.Models;

namespace LibraryOrganizer.Controllers
{
    public class AuthorController : Controller
    {
        private Repository<Author> authors { get; set; }
        public AuthorController(LibraryContext ctx) => authors = new Repository<Author>(ctx);

        public ViewResult Index()
        {
            var options = new QueryOptions<Author> {
                OrderBy = t => t.LastName
            };
            return View(authors.List(options));
        }

        [HttpGet]
        public ViewResult Add() => View();

        [HttpPost]
        public IActionResult Add(Author author)
        {
            if (ModelState.IsValid) {
                authors.Insert(author);
                authors.Save();
                return RedirectToAction("Index");
            }
            else{
                return View(author);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            return View(authors.Get(id));
        }

        [HttpPost]
        public RedirectToActionResult Delete(Author author)
        {
            authors.Delete(author);
            authors.Save();
            return RedirectToAction("Index");
        }
    }
}