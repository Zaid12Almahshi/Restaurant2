using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repositories;
using Restaurant.Models;
using System;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TransactionNewsletterController : Controller
    {
        public IRepository<TransactionNewsletter> TransactionNewsletter { get; }

        public TransactionNewsletterController(IRepository<TransactionNewsletter> _TransactionNewsletter)
        {
            TransactionNewsletter = _TransactionNewsletter;
        }
        // GET: TransactionNewsletterController
        public ActionResult Index()
        {
            return View(TransactionNewsletter.View());
        }

        // GET: TransactionNewsletterController/Details/5
        public ActionResult Details(int id)
        {
            return View(TransactionNewsletter.Find(id));
        }

        // GET: TransactionNewsletterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionNewsletterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionNewsletter collection)
        {
            try
            {
                collection.CreateDate = DateTime.Now;
                collection.CreateUser = User.Identity.Name;
                TransactionNewsletter.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionNewsletterController/Edit/5
        public ActionResult Edit(int id)
        {
            var data= TransactionNewsletter.Find(id);
            return View(data);
        }

        // POST: TransactionNewsletterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransactionNewsletter collection)
        {
            try
            {
                collection.EditDate = DateTime.Now;
                collection.EditUser = User.Identity.Name;
                TransactionNewsletter.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionNewsletterController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = TransactionNewsletter.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            TransactionNewsletter.Delete(id, data);
            return RedirectToAction(nameof(Index));
        }

        // POST: TransactionNewsletterController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, TransactionNewsletter collection)
        //{
        //    try
        //    {
        //        collection.EditDate = DateTime.Now;
        //        collection.EditUser = User.Identity.Name;
        //        TransactionNewsletter.Delete(id, collection);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        public ActionResult Active(int id)
        {
            var data = TransactionNewsletter.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            TransactionNewsletter.Active(id, data);
            return RedirectToAction(nameof(Index));
        }
    }
}
