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
    public class MasterServiceController : Controller
    {
        public IRepository<MasterService> MasterService { get; }
        public IHostingEnvironment Host { get; }

        public MasterServiceController(IRepository<MasterService> _MasterService,IHostingEnvironment _Host)
        {
            MasterService = _MasterService;
            Host = _Host;
        }
        // GET: MasterServiceController
        public ActionResult Index()
        {
            return View(MasterService.View());
        }

        // GET: MasterServiceController/Details/5
        public ActionResult Details(int id)
        {
            return View(MasterService.Find(id));
        }

        // GET: MasterServiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterServiceModel collection)
        {
            try
            {
                string ImageName = SaveImage(collection.File);
                MasterService model=new MasterService();
                model.CreateDate = DateTime.Now;
                model.CreateUser = User.Identity.Name;
                model.IsActive = collection.IsActive;
                model.MasterServiceId = collection.MasterServiceId;
                model.MasterServiceDesc = collection.MasterServiceDesc;
                model.MasterServiceTitle= collection.MasterServiceTitle;
                model.MasterServiceLogo = collection.MasterServiceLogo;
                model.MasterServiceImage = ImageName;
                MasterService.Add(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterServiceController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterService.Find(id);
            MasterServiceModel model = new MasterServiceModel();
            
            model.IsActive = data.IsActive;
            model.MasterServiceId = data.MasterServiceId;
            model.MasterServiceDesc = data.MasterServiceDesc;
            model.MasterServiceTitle = data.MasterServiceTitle;
            model.MasterServiceLogo = data.MasterServiceLogo;
            model.MasterServiceImage = data.MasterServiceImage;
            return View(model);
        }

        // POST: MasterServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterServiceModel collection)
        {
            try
            {
                string ImageName = SaveImage(collection.File);
                MasterService model = new MasterService();
                model.EditDate = DateTime.Now;
                model.EditUser = User.Identity.Name;
                model.IsActive = collection.IsActive;
                model.MasterServiceId = collection.MasterServiceId;
                model.MasterServiceDesc = collection.MasterServiceDesc;
                model.MasterServiceTitle = collection.MasterServiceTitle;
                model.MasterServiceLogo = collection.MasterServiceLogo;
                model.MasterServiceImage = ImageName;
                MasterService.Update(id, model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterServiceController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = MasterService.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterService.Delete(id, data);
            return RedirectToAction(nameof(Index));
        }

        // POST: MasterServiceController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, MasterService collection)
        //{
        //    try
        //    {
        //        collection.EditDate = DateTime.Now;
        //        collection.EditUser = User.Identity.Name;
        //        MasterService.Delete(id, collection);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        public ActionResult Active(int id)
        {
            var data = MasterService.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterService.Active(id, data);
            return RedirectToAction(nameof(Index));
        }
        string SaveImage(IFormFile file)
        {
            string ImageName = "";
            if (file != null)
            {
                string Filepath = Path.Combine(Host.WebRootPath, "Images/MasterService");
                FileInfo fil = new FileInfo(file.FileName);
                ImageName = "Image_" + Guid.NewGuid() + fil.Extension;
                string FullPath = Path.Combine(Filepath, ImageName);
                file.CopyTo(new FileStream(FullPath, FileMode.Create));
            }
            return ImageName;
        }
    }
}
