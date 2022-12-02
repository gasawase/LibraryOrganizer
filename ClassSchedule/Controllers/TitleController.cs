using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LibraryOrganizer.Models;

namespace LibraryOrganizer.Controllers
{
    public class TitleController : Controller
    {
        private LibraryOrganizerUnitOfWork<Title> titles { get; set; }
        private LibraryOrganizerUnitOfWork<Author> authors { get; set; }

        public TitleController(LibraryContext ctx)
        {
            titles = new LibraryOrganizerUnitOfWork<Title>(ctx);
            authors = new LibraryOrganizerUnitOfWork<Author>(ctx);
        }

        public RedirectToActionResult Index() => RedirectToAction("Index", "Home");
        

        [HttpGet]
        public ViewResult Add()
        {
            this.LoadViewBag("Add");
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            this.LoadViewBag("Edit");
            var c = this.GetTitle(id);
            return View("Add", c);
        }

        [HttpPost]
        public IActionResult Add(Title c)
        {
            if (ModelState.IsValid) {
                if (c.Id == 0)
                    titles.Titles.Insert(c);
                else
                    titles.Titles.Update(c);
                titles.Save();
                return RedirectToAction("Index", "Home");
            }
            else {
                string operation = (c.Id == 0) ? "Add" : "Edit";
                this.LoadViewBag(operation);
                return View();
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var c = this.GetTitle(id);
            return View(c);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Title c)
        {
            titles.Titles.Delete(c);
            titles.Save();
            return RedirectToAction("Index", "Home");
        }

        // private helper methods
        private Title GetTitle(int id)
        {
            var classOptions = new QueryOptions<Title>
            {
                Includes = "Author",
                Where = c => c.Id == id
            };
            var list = titles.Titles.List(classOptions);
            var get = titles.Titles.Get(classOptions);

            // return first Class or blank Class if null
            return get;
        }
        private void LoadViewBag(string operation)
        {
            ViewBag.Authors = authors.Authors.List(new QueryOptions<Author> {
                OrderBy = t => t.LastName
            });
            ViewBag.Operation = operation;
        }
    }
}