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
    public class MasterPartnerController : Controller
    {
        public IRepository<MasterPartner> MasterPartner { get; }
        public IHostingEnvironment Host { get; }

        public MasterPartnerController(IRepository<MasterPartner> _MasterPartner,IHostingEnvironment _Host)
        {
            MasterPartner = _MasterPartner;
            Host = _Host;
        }
        // GET: MasterPartnerController
        public ActionResult Index()
        {
            return View(MasterPartner.View());
        }

        // GET: MasterPartnerController/Details/5
        public ActionResult Details(int id)
        {
            return View(MasterPartner.Find(id));
        }

        // GET: MasterPartnerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterPartnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterPartnerModel collection)
        {
            try
            {
                string ImageName = SaveImage(collection.File);
                MasterPartner model=new MasterPartner();
                model.CreateDate = DateTime.Now;
                model.CreateUser = User.Identity.Name;
                model.IsActive = collection.IsActive;
                model.MasterPartnerId= collection.MasterPartnerId;
                model.MasterPartnerName= collection.MasterPartnerName;
                model.MasterPartnerWebsiteUrl= collection.MasterPartnerWebsiteUrl;
                model.MasterPartnerLogoImageUrl = ImageName;
                MasterPartner.Add(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterPartnerController/Edit/5
        public ActionResult Edit(int id)
        {
            var data=MasterPartner.Find(id);
            MasterPartnerModel model = new MasterPartnerModel();
           
            model.IsActive = data.IsActive;
            model.MasterPartnerId = data.MasterPartnerId;
            model.MasterPartnerName = data.MasterPartnerName;
            model.MasterPartnerWebsiteUrl = data.MasterPartnerWebsiteUrl;
            model.MasterPartnerLogoImageUrl = data.MasterPartnerLogoImageUrl;
            return View(model);
        }

        // POST: MasterPartnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterPartnerModel collection)
        {
            try
            {
                string ImageName = SaveImage(collection.File);
                if (collection.File==null)
                {
                    ImageName = collection.MasterPartnerLogoImageUrl;
                }
                MasterPartner model = new MasterPartner();
                model.EditDate = DateTime.Now;
                model.EditUser = User.Identity.Name;
                model.IsActive = collection.IsActive;
                model.MasterPartnerId = collection.MasterPartnerId;
                model.MasterPartnerName = collection.MasterPartnerName;
                model.MasterPartnerWebsiteUrl = collection.MasterPartnerWebsiteUrl;
                model.MasterPartnerLogoImageUrl = ImageName;
                MasterPartner.Update(id, model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterPartnerController/Delete/5
        public ActionResult Delete(int id)
        {
            var data=MasterPartner.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterPartner.Delete(id, data);
            return RedirectToAction(nameof(Index));
        }

        // POST: MasterPartnerController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, MasterPartner collection)
        //{
        //    try
        //    {
        //        collection.EditDate = DateTime.Now;
        //        collection.EditUser = User.Identity.Name;
        //        MasterPartner.Delete(id, collection);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        public ActionResult Active(int id)
        {
            var data = MasterPartner.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterPartner.Active(id, data);
            return RedirectToAction(nameof(Index));
        }
        string SaveImage(IFormFile file)
        {
            string ImageName = "";
            if (file != null)
            {
                string Filepath = Path.Combine(Host.WebRootPath, "Images/MasterPartner");
                FileInfo fil = new FileInfo(file.FileName);
                ImageName = "Image_" + Guid.NewGuid() + fil.Extension;
                string FullPath = Path.Combine(Filepath, ImageName);
                file.CopyTo(new FileStream(FullPath, FileMode.Create));
            }
            return ImageName;
        }
    }
}
