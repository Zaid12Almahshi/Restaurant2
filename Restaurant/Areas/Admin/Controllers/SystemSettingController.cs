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
    public class SystemSettingController : Controller
    {
        public IRepository<SystemSetting> SystemSetting { get; }
        public IHostingEnvironment Host { get; }

        public SystemSettingController(IRepository<SystemSetting> _SystemSetting,IHostingEnvironment _Host)
        {
            SystemSetting = _SystemSetting;
            Host = _Host;
        }
        // GET: SystemSettingController
        public ActionResult Index()
        {
            return View(SystemSetting.View());
        }

        // GET: SystemSettingController/Details/5
        public ActionResult Details(int id)
        {
            return View(SystemSetting.Find(id));
        }

        // GET: SystemSettingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemSettingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SystemSettingModel collection)
        {
            try
            {
                string ImageName = SaveImage(collection.File);
                string ImageName2 = SaveImage(collection.File1);
                string ImageName3 = SaveImage(collection.File2);
                SystemSetting model=new SystemSetting();
                model.CreateDate = DateTime.Now;
                model.CreateUser = User.Identity.Name;
                model.IsActive = collection.IsActive;
                model.SystemSettingId= collection.SystemSettingId;
                model.SystemSettingMapLocation= collection.SystemSettingMapLocation;
                model.SystemSettingWelcomeNoteBreef=collection.SystemSettingWelcomeNoteBreef;
                model.SystemSettingWelcomeNoteDesc=collection.SystemSettingWelcomeNoteDesc;
                model.SystemSettingWelcomeNoteUrl=collection.SystemSettingWelcomeNoteUrl;
                model.SystemSettingCopyright=collection.SystemSettingCopyright;
                model.SystemSettingWelcomeNoteTitle=collection.SystemSettingWelcomeNoteTitle;
                model.SystemSettingPhoneNumber = collection.SystemSettingPhoneNumber;
                model.SystemSettingEmail = collection.SystemSettingEmail;
                model.SystemSettingLogoImageUrl = ImageName;
                model.SystemSettingLogoImageUrl2 = ImageName2;
                model.SystemSettingWelcomeNoteImageUrl = ImageName3;
                SystemSetting.Add(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemSettingController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = SystemSetting.Find(id);
            SystemSettingModel model = new SystemSettingModel();
            
            model.IsActive = data.IsActive;
            model.SystemSettingId = data.SystemSettingId;
            model.SystemSettingMapLocation = data.SystemSettingMapLocation;
            model.SystemSettingWelcomeNoteBreef = data.SystemSettingWelcomeNoteBreef;
            model.SystemSettingWelcomeNoteDesc = data.SystemSettingWelcomeNoteDesc;
            model.SystemSettingWelcomeNoteUrl = data.SystemSettingWelcomeNoteUrl;
            model.SystemSettingCopyright = data.SystemSettingCopyright;
            model.SystemSettingWelcomeNoteTitle = data.SystemSettingWelcomeNoteTitle;
            model.SystemSettingLogoImageUrl = data.SystemSettingLogoImageUrl;
            model.SystemSettingLogoImageUrl2 = data.SystemSettingLogoImageUrl2;
            model.SystemSettingPhoneNumber = data.SystemSettingPhoneNumber;
            model.SystemSettingEmail = data.SystemSettingEmail;
            model.SystemSettingWelcomeNoteImageUrl = data.SystemSettingWelcomeNoteImageUrl;
            return View(model);
        }

        // POST: SystemSettingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SystemSettingModel collection)
        {
            try
            {
                string ImageName = SaveImage(collection.File);
                string ImageName2 = SaveImage(collection.File1);
                string ImageName3 = SaveImage(collection.File2);
                if(collection.File==null)
                {
                    ImageName = collection.SystemSettingLogoImageUrl;

                }
                if (collection.File1 == null)
                {
                    ImageName = collection.SystemSettingLogoImageUrl2;

                }
                if (collection.File2 == null)
                {
                    ImageName = collection.SystemSettingWelcomeNoteImageUrl;

                }
                SystemSetting model = new SystemSetting();
                model.EditDate = DateTime.Now;
                model.EditUser = User.Identity.Name;
                model.IsActive = collection.IsActive;
                model.SystemSettingId = collection.SystemSettingId;
                model.SystemSettingMapLocation = collection.SystemSettingMapLocation;
                model.SystemSettingWelcomeNoteBreef = collection.SystemSettingWelcomeNoteBreef;
                model.SystemSettingWelcomeNoteDesc = collection.SystemSettingWelcomeNoteDesc;
                model.SystemSettingWelcomeNoteUrl = collection.SystemSettingWelcomeNoteUrl;
                model.SystemSettingCopyright = collection.SystemSettingCopyright;
                model.SystemSettingWelcomeNoteTitle = collection.SystemSettingWelcomeNoteTitle;
                model.SystemSettingPhoneNumber = collection.SystemSettingPhoneNumber;
                model.SystemSettingEmail = collection.SystemSettingEmail;
                model.SystemSettingLogoImageUrl = ImageName;
                model.SystemSettingLogoImageUrl2 = ImageName2;
                model.SystemSettingWelcomeNoteImageUrl = ImageName3;
                SystemSetting.Update(id, model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemSettingController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = SystemSetting.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            SystemSetting.Delete(id, data);
            return RedirectToAction(nameof(Index));
        }

        // POST: SystemSettingController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, SystemSetting collection)
        //{
        //    try
        //    {
        //        collection.EditDate = DateTime.Now;
        //        collection.EditUser = User.Identity.Name;
        //        SystemSetting.Delete(id, collection);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        public ActionResult Active(int id)
        {
            var data = SystemSetting.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            SystemSetting.Active(id, data);
            return RedirectToAction(nameof(Index));
        }
        string SaveImage(IFormFile file)
        {
            string ImageName = "";
            if (file != null)
            {
                string Filepath = Path.Combine(Host.WebRootPath, "Images/SystemSetting");
                FileInfo fil = new FileInfo(file.FileName);
                ImageName = "Image_" + Guid.NewGuid() + fil.Extension;
                string FullPath = Path.Combine(Filepath, ImageName);
                file.CopyTo(new FileStream(FullPath, FileMode.Create));
            }
            return ImageName;
        }
    }
}
