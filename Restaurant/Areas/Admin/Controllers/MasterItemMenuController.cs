using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repositories;
using Restaurant.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;
using Restaurant.ViewModels;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MasterItemMenuController : Controller
    {
        public IRepository<MasterItemMenu> MasterItemMenu { get; }
        public IHostingEnvironment Host { get; }
        public IRepository<MasterCategoryMenu> MasterCategoryMenu { get; }

        public MasterItemMenuController(IRepository<MasterItemMenu> _MasterItemMenu, IHostingEnvironment _Host, IRepository<MasterCategoryMenu> _MasterCategoryMenu)
        {
            MasterItemMenu = _MasterItemMenu;
            Host = _Host;
            MasterCategoryMenu = _MasterCategoryMenu;
        }
        // GET: MasterItemMenuController
        public ActionResult Index()
        {
            return View(MasterItemMenu.View());
        }

        // GET: MasterItemMenuController/Details/5
        public ActionResult Details(int id)
        {
            return View(MasterItemMenu.Find(id));
        }

        // GET: MasterItemMenuController/Create
        public ActionResult Create()
        {
            ViewBag.listMasterCategoryMenu = MasterCategoryMenu.View();
            return View();
        }

        // POST: MasterItemMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterItemMenuModel collection)
        {
            try
            {
                string ImageName = SaveImage(collection.File);
                MasterItemMenu model = new MasterItemMenu();
                model.CreateDate = DateTime.Now;
                model.CreateUser = User.Identity.Name;
                model.MasterItemMenuId = collection.MasterItemMenuId;
                model.MasterItemMenuDate = collection.MasterItemMenuDate;
                model.MasterItemMenuDesc = collection.MasterItemMenuDesc;
                model.MasterItemMenuPrice = collection.MasterItemMenuPrice;
                model.MasterItemMenuTitle = collection.MasterItemMenuTitle;
                model.MasterItemMenuBreef = collection.MasterItemMenuBreef;
                model.MasterCategoryMenuId = collection.MasterCategoryMenuId;
                model.MasterItemMenuImageUrl = ImageName;
                MasterItemMenu.Add(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterItemMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.listMasterCategoryMenu = MasterCategoryMenu.View();
            var data = MasterItemMenu.Find(id);
            MasterItemMenuModel model = new MasterItemMenuModel();

            model.IsActive = data.IsActive;
            model.MasterItemMenuId = data.MasterItemMenuId;
            model.MasterItemMenuDate = data.MasterItemMenuDate;
            model.MasterItemMenuDesc = data.MasterItemMenuDesc;
            model.MasterItemMenuPrice = data.MasterItemMenuPrice;
            model.MasterItemMenuTitle = data.MasterItemMenuTitle;
            model.MasterItemMenuBreef = data.MasterItemMenuBreef;
            model.MasterCategoryMenuId = data.MasterCategoryMenuId;
            model.MasterItemMenuImageUrl = data.MasterItemMenuImageUrl;
            return View(model);
        }

        // POST: MasterItemMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterItemMenuModel collection)
        {
            try
            {
                string ImageName = SaveImage(collection.File);
                if (collection.File == null)
                {
                    ImageName = collection.MasterItemMenuImageUrl;
                }
                MasterItemMenu model = new MasterItemMenu();
                model.EditDate = DateTime.Now;
                model.EditUser = User.Identity.Name;
                model.IsActive = collection.IsActive;
                model.MasterItemMenuId = collection.MasterItemMenuId;
                model.MasterItemMenuDate = collection.MasterItemMenuDate;
                model.MasterItemMenuDesc = collection.MasterItemMenuDesc;
                model.MasterItemMenuPrice = collection.MasterItemMenuPrice;
                model.MasterItemMenuTitle = collection.MasterItemMenuTitle;
                model.MasterItemMenuBreef = collection.MasterItemMenuBreef;
                model.MasterCategoryMenuId = collection.MasterCategoryMenuId;
                model.MasterItemMenuImageUrl = ImageName;
                MasterItemMenu.Update(id, model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterItemMenuController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = MasterItemMenu.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterItemMenu.Delete(id, data);
            return RedirectToAction(nameof(Index));
        }

        // POST: MasterItemMenuController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, MasterItemMenu collection)
        //{
        //    try
        //    {
        //        collection.EditDate = DateTime.Now;
        //        collection.EditUser = User.Identity.Name;
        //        MasterItemMenu.Delete(id, collection);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        public ActionResult Active(int id)
        {
            var data = MasterItemMenu.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterItemMenu.Active(id, data);
            return RedirectToAction(nameof(Index));
        }
        string SaveImage(IFormFile file)
        {
            string ImageName = "";
            if (file != null)
            {
                string Filepath = Path.Combine(Host.WebRootPath, "Images/MasterItemMenu");
                FileInfo fil = new FileInfo(file.FileName);
                ImageName = "Image_" + Guid.NewGuid() + fil.Extension;
                string FullPath = Path.Combine(Filepath, ImageName);
                file.CopyTo(new FileStream(FullPath, FileMode.Create));
            }
            return ImageName;
        }
    }
}
