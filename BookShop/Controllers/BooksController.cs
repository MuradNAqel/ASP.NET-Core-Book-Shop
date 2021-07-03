using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class BooksController : Controller
    {
        public static List<Book> BooksList = new List<Book>
        {

        };
        public ActionResult Index()
        {
            return View(BooksList);
        }

        public ActionResult Details(int id)
        {
            Book model = BooksList.FirstOrDefault(b => b.BookId == id);
            if (model is null)
                return RedirectToAction(nameof(Index));
            return View(model);
        }

        public ActionResult Create()
        {
            return View(new Book());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book model)
        {

                if (ModelState.IsValid)
                {
                    model.BookId = BooksList.Count + 1;
                    BooksList.Add(model);
                    return RedirectToAction(nameof(Index));
                }
                return View(model);

        }
        

        public ActionResult Edit(int id)
        {
            Book model = BooksList.FirstOrDefault(b => b.BookId == id);
            if (model is null)
                return RedirectToAction(nameof(Index));
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book model)
        {
            if (ModelState.IsValid)
            {
                BooksList.Remove(BooksList.FirstOrDefault(b => b.BookId == id));
                BooksList.Add(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            Book model = BooksList.FirstOrDefault(b => b.BookId == id);
            if (model is null)
                return RedirectToAction(nameof(Index));
            return View(model);
        }

        public ActionResult DeleteConf(int id) 
        {
            BooksList.Remove(BooksList.FirstOrDefault(b => b.BookId == id));
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
