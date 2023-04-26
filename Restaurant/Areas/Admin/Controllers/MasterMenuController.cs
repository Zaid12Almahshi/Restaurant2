using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repositories;
using Restaurant.Models;
using System;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MasterMenuController : Controller
    {
        public IRepository<MasterMenu> MasterMenu { get; }

        public MasterMenuController(IRepository<MasterMenu> _MasterMenu)
        {
            MasterMenu = _MasterMenu;
        }
        // GET: MasterMenuController
        public ActionResult Index()
        {
            return View(MasterMenu.View());
        }

        // GET: MasterMenuController/Details/5
        public ActionResult Details(int id)
        {
            return View(MasterMenu.Find(id));
        }

        // GET: MasterMenuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterMenu collection)
        {
            try
            {
                collection.CreateDate = DateTime.Now;
                collection.CreateUser = User.Identity.Name;
                MasterMenu.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterMenu.Find(id);
            return View(data);
        }

        // POST: MasterMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterMenu collection)
        {
            try
            {
                collection.EditDate = DateTime.Now;
                collection.EditUser = User.Identity.Name;
                MasterMenu.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterMenuController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = MasterMenu.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterMenu.Delete(id, data);
            return RedirectToAction(nameof(Index));
        }

        // POST: MasterMenuController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, MasterMenu collection)
        //{
        //    try
        //    {
        //        collection.EditDate = DateTime.Now;
        //        collection.EditUser = User.Identity.Name;
        //        MasterMenu.Delete(id, collection);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        public ActionResult Active(int id)
        {
            var data = MasterMenu.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterMenu.Active(id, data);
            return RedirectToAction(nameof(Index));
        }
    }
}
