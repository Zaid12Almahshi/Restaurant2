using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repositories;
using Restaurant.Models;
using System;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MasterWorkingHourController : Controller
    {
        public IRepository<MasterWorkingHour> MasterWorkingHour { get; }

        public MasterWorkingHourController(IRepository<MasterWorkingHour> _MasterWorkingHour)
        {
            MasterWorkingHour = _MasterWorkingHour;
        }
        // GET: MasterWorkingHourController
        public ActionResult Index()
        {
            return View(MasterWorkingHour.View());
        }

        // GET: MasterWorkingHourController/Details/5
        public ActionResult Details(int id)
        {
            return View(MasterWorkingHour.Find(id));
        }

        // GET: MasterWorkingHourController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterWorkingHourController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterWorkingHour collection)
        {
            try
            {
                collection.CreateDate = DateTime.Now;
                collection.CreateUser = User.Identity.Name;
                MasterWorkingHour.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterWorkingHourController/Edit/5
        public ActionResult Edit(int id)
        {
            var data=MasterWorkingHour.Find(id);
            return View(data);
        }

        // POST: MasterWorkingHourController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterWorkingHour collection)
        {
            try
            {
                collection.EditDate = DateTime.Now;
                collection.EditUser = User.Identity.Name;
                MasterWorkingHour.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterWorkingHourController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = MasterWorkingHour.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterWorkingHour.Delete(id, data);
            return RedirectToAction(nameof(Index));
        }

        // POST: MasterWorkingHourController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, MasterWorkingHour collection)
        //{
        //    try
        //    {
        //        collection.EditDate = DateTime.Now;
        //        collection.EditUser = User.Identity.Name;
        //        MasterWorkingHour.Delete(id, collection);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        public ActionResult Active(int id)
        {
            var data = MasterWorkingHour.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterWorkingHour.Active(id, data);
            return RedirectToAction(nameof(Index));
        }
    }
}
