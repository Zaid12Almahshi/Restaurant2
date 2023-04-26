using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repositories;
using Restaurant.Models;
using System;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TransactionContactUController : Controller
    {
        
        public IRepository<TransactionContactU> TransactionContactU { get; }

        public TransactionContactUController(IRepository<TransactionContactU> _TransactionContactU)
        {
            TransactionContactU = _TransactionContactU;
        }
        // GET: TransactionContactUController
        public ActionResult Index()
        {
            return View(TransactionContactU.View());
        }

        // GET: TransactionContactUController/Details/5
        public ActionResult Details(int id)
        {
            return View(TransactionContactU.Find(id));
        }

        // GET: TransactionContactUController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionContactUController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionContactU collection)
        {
            try
            {
                collection.CreateDate = DateTime.Now;
                collection.CreateUser = User.Identity.Name;
                TransactionContactU.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionContactUController/Edit/5
        public ActionResult Edit(int id)
        {

            var data= TransactionContactU.Find(id); 
            return View(data);
        }

        // POST: TransactionContactUController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransactionContactU collection)
        {
            try
            {
                collection.EditDate = DateTime.Now;
                collection.EditUser = User.Identity.Name;
                TransactionContactU.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionContactUController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = TransactionContactU.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            TransactionContactU.Delete(id, data);
            return RedirectToAction(nameof(Index));
        }

        // POST: TransactionContactUController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, TransactionContactU collection)
        //{
        //    try
        //    {
        //        collection.EditDate = DateTime.Now;
        //        collection.EditUser = User.Identity.Name;
        //        TransactionContactU.Delete(id, collection);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        public ActionResult Active(int id)
        {
            var data = TransactionContactU.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            TransactionContactU.Active(id, data);
            return RedirectToAction(nameof(Index));
        }
    }
}
