using BookStore.Entities;
using BookStore.Models;
using BookStore.Services;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(BookController).Name);
        private IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: Book
        public ActionResult Index()
        {
            return View(_bookService.GetAllBooks());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Description,Author,Price")] BookViewModel bookVm)
        {
            _log.Info("Start Create Book");
            if (ModelState.IsValid)
            {
                _bookService.CreateBook(bookVm);
                return RedirectToAction("Index");
            }

            return View(bookVm);
        }

        public ActionResult Edit(int id)
        {
            BookViewModel bookVm = _bookService.GetBook(id);
            if (bookVm == null)
            {
                return HttpNotFound();
            }
            return View(bookVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description,Author,Price")] BookViewModel bookVm)
        {
            _log.Info("Start Edit Book");
            _bookService.UpdateBook(bookVm);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            BookViewModel bookVm = _bookService.GetBook(id);
            if (bookVm == null)
            {
                return HttpNotFound();
            }
            return View(bookVm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _log.Info("Start Delete Book");
            _bookService.DeleteBook(id);
            return RedirectToAction("Index");
        }
    }
}