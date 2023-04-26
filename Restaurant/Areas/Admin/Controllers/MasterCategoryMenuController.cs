using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repositories;
using Restaurant.Models;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Web;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MasterCategoryMenuController : Controller
    {
        public IRepository<MasterCategoryMenu> MasterCategoryMenu { get; }

        public MasterCategoryMenuController(IRepository<MasterCategoryMenu> _MasterCategoryMenu)
        {
            MasterCategoryMenu = _MasterCategoryMenu;
        }
        // GET: MasterCategoryMenuController
        public ActionResult Index()
        {


            return View(MasterCategoryMenu.View());
        }


        // GET: MasterCategoryMenuController/Details/5
        public ActionResult Details(int id)
        {

            return View(MasterCategoryMenu.Find(id));
        }

        // GET: MasterCategoryMenuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterCategoryMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterCategoryMenu collection)
        {
            try
            {
               
                collection.CreateDate = DateTime.Now;
                collection.CreateUser = User.Identity.Name;
                MasterCategoryMenu.Add(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterCategoryMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterCategoryMenu.Find(id);
            return View(data);
        }

        // POST: MasterCategoryMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterCategoryMenu collection)
        {
            try
            {
                collection.EditDate = DateTime.Now;
                collection.EditUser = User.Identity.Name;
                MasterCategoryMenu.Update(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterCategoryMenuController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var data=MasterCategoryMenu.Find(id);
                data.EditDate = DateTime.Now;
                data.EditUser = User.Identity.Name;
                MasterCategoryMenu.Delete(id,data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            //return View(data);
        }

        // POST: MasterCategoryMenuController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, MasterCategoryMenu collection)
        //{
        //    try
        //    {
        //        MasterCategoryMenu.Delete(id, new Models.MasterCategoryMenu { EditDate = DateTime.Now, EditUser = User.Identity.Name });
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        public ActionResult Active(int id)
        {
            var data = MasterCategoryMenu.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterCategoryMenu.Active(id, data);
            return RedirectToAction(nameof(Index));
        }
    }
}
