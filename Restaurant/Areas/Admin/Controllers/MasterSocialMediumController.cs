using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repositories;
using Restaurant.Models;
using Microsoft.AspNetCore.Hosting;
using Restaurant.ViewModels;
using System.IO;
using System;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MasterSocialMediumController : Controller
    {
        public IRepository<MasterSocialMedium> MasterSocialMedium { get; }
        public IHostingEnvironment Host { get; }

        public MasterSocialMediumController(IRepository<MasterSocialMedium> _MasterSocialMedium,IHostingEnvironment _Host)
        {
            MasterSocialMedium = _MasterSocialMedium;
            Host = _Host;
        }
        // GET: MasterSocialMediumController
        public ActionResult Index()
        {
            return View(MasterSocialMedium.View());
        }

        // GET: MasterSocialMediumController/Details/5
        public ActionResult Details(int id)
        {
            return View(MasterSocialMedium.Find(id));
        }

        // GET: MasterSocialMediumController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterSocialMediumController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterSocialMediumModel collection)
        {
            try
            {
                string ImageName = SaveImage(collection.File);
                MasterSocialMedium model= new MasterSocialMedium();
                model.CreateDate = DateTime.Now;
                model.CreateUser = User.Identity.Name;
                model.IsActive = collection.IsActive;
                model.MasterSocialMediumId= collection.MasterSocialMediumId;
                model.MasterSocialMediumUrl= collection.MasterSocialMediumUrl;
                model.MasterSocialMediumName = collection.MasterSocialMediumName;
                model.MasterSocialMediumImageUrl = ImageName;
                MasterSocialMedium.Add(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSocialMediumController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterSocialMedium.Find(id);
            MasterSocialMediumModel model = new MasterSocialMediumModel();
           
            model.IsActive = data.IsActive;
            model.MasterSocialMediumId = data.MasterSocialMediumId;
            model.MasterSocialMediumUrl = data.MasterSocialMediumUrl;
            model.MasterSocialMediumImageUrl = data.MasterSocialMediumImageUrl;
            model.MasterSocialMediumName = data.MasterSocialMediumName;
            return View(model);
        }

        // POST: MasterSocialMediumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterSocialMediumModel collection)
        {
            try
            {
                string ImageName = SaveImage(collection.File);
                MasterSocialMedium model = new MasterSocialMedium();
                model.EditDate = DateTime.Now;
                model.EditUser = User.Identity.Name;
                model.IsActive = collection.IsActive;
                model.MasterSocialMediumId = collection.MasterSocialMediumId;
                model.MasterSocialMediumUrl = collection.MasterSocialMediumUrl;
                model.MasterSocialMediumName = collection.MasterSocialMediumName;
                model.MasterSocialMediumImageUrl = ImageName;
                MasterSocialMedium.Update(id, model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSocialMediumController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = MasterSocialMedium.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterSocialMedium.Delete(id, data);
            return RedirectToAction(nameof(Index));
        }

        // POST: MasterSocialMediumController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, MasterSocialMedium collection)
        //{
        //    try
        //    {
        //        collection.EditDate = DateTime.Now;
        //        collection.EditUser = User.Identity.Name;
        //        MasterSocialMedium.Delete(id, collection);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        [HttpPost]
        public ActionResult Active(int id)
        {
            var data = MasterSocialMedium.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterSocialMedium.Active(id, data);
            return RedirectToAction(nameof(Index));
        }
        string SaveImage(IFormFile file)
        {
            string ImageName = "";
            if (file != null)
            {
                string Filepath = Path.Combine(Host.WebRootPath, "Images/MasterSocialMedium");
                FileInfo fil = new FileInfo(file.FileName);
                ImageName = "Image_" + Guid.NewGuid() + fil.Extension;
                string FullPath = Path.Combine(Filepath, ImageName);
                file.CopyTo(new FileStream(FullPath, FileMode.Create));
            }
            return ImageName;
        }
    }
}
