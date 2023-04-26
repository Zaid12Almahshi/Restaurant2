using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repositories;
using Restaurant.Models;
using System;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TransactionBookTableController : Controller
    {
        public IRepository<TransactionBookTable> TransactionBookTable { get; }

        public TransactionBookTableController(IRepository<TransactionBookTable> _TransactionBookTable)
        {
            TransactionBookTable = _TransactionBookTable;
        }
        // GET: TransactionBookTableController
        public ActionResult Index()
        {
            return View(TransactionBookTable.View());
        }

        // GET: TransactionBookTableController/Details/5
        public ActionResult Details(int id)
        {
            return View(TransactionBookTable.Find(id));
        }

        // GET: TransactionBookTableController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionBookTableController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionBookTable collection)
        {
            try
            {
                collection.CreateDate = DateTime.Now;
                collection.CreateUser = User.Identity.Name;
                TransactionBookTable.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionBookTableController/Edit/5
        public ActionResult Edit(int id)
        {
            var data= TransactionBookTable.Find(id);
            return View(data);
        }

        // POST: TransactionBookTableController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransactionBookTable collection)
        {
            try
            {
                collection.EditDate = DateTime.Now;
                collection.EditUser = User.Identity.Name;
                TransactionBookTable.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionBookTableController/Delete/5
        public ActionResult Delete(int id)
        {
            var data=TransactionBookTable.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            TransactionBookTable.Delete(id, data);
            return RedirectToAction(nameof(Index));
        }

        // POST: TransactionBookTableController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, TransactionBookTable collection)
        //{
        //    try
        //    {
        //        collection.EditDate = DateTime.Now;
        //        collection.EditUser = User.Identity.Name;
        //        TransactionBookTable.Delete(id, collection);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        public ActionResult Active(int id)
        {
            var data = TransactionBookTable.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            TransactionBookTable.Active(id, data);
            return RedirectToAction(nameof(Index));
        }
    }
}
