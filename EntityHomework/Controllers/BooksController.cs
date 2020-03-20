using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityHomework.Data;
using EntityHomework.Models;
using EntityHomework.Persistence;

namespace EntityHomework.Controllers
{
    public class BooksController : Controller
    {

        private UnitOfWork UnitOfWork = new UnitOfWork();

        // GET: Books
        public ActionResult Index(string SearchString = "")
        {
            List<Book> Books = UnitOfWork.Books.GetAll().ToList();
            
            if (!SearchString.Equals(""))
            {
                Books = Books.Where(b => b.Name.ToLower().Contains(SearchString.ToLower()) || b.Author.Name.ToLower().Contains(SearchString.ToLower())).ToList();
            }
            
            return View(Books);
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = UnitOfWork.Books.Get(id);

            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(UnitOfWork.Authors.GetAll().ToList(), "Id", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Count,AuthorId")] Book book)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.Books.Add(book);
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(UnitOfWork.Authors.GetAll(), "Id", "Name", book.AuthorId);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = UnitOfWork.Books.Get(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(UnitOfWork.Authors.GetAll(), "Id", "Name", book.AuthorId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book book)
        {
            
            if (ModelState.IsValid)
            {

                UnitOfWork.Books.Update(id, book);
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(UnitOfWork.Authors.GetAll(), "Id", "Name", book.AuthorId);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = UnitOfWork.Books.Get(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = UnitOfWork.Books.Get(id);
            UnitOfWork.Books.Remove(book);
            return RedirectToAction("Index");
        }

    }
}
