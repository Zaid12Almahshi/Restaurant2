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
    public class MasterOfferController : Controller
    {
        public IRepository<MasterOffer> MasterOffer { get; }
        public IHostingEnvironment Host { get; }

        public MasterOfferController(IRepository<MasterOffer> MasterOffer,IHostingEnvironment _Host)
        {
            this.MasterOffer = MasterOffer;
            Host = _Host;
        }
        // GET: MasterOfferController
        public ActionResult Index()
        {
            return View(MasterOffer.View());
        }

        // GET: MasterOfferController/Details/5
        public ActionResult Details(int id)
        {
            return View(MasterOffer.Find(id));
        }

        // GET: MasterOfferController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterOfferController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterOfferModel collection)
        {
            try
            {
                string ImageName = SaveImage(collection.File);
                MasterOffer model=new MasterOffer();
                model.CreateDate = DateTime.Now;
                model.CreateUser = User.Identity.Name;
                model.IsActive = collection.IsActive;
                model.MasterOfferId = collection.MasterOfferId;
                model.MasterOfferTitle= collection.MasterOfferTitle;
                model.MasterOfferDesc= collection.MasterOfferDesc;
                model.MasterOfferBreef= collection.MasterOfferBreef;
                model.MasterOfferImageUrl = ImageName;
                MasterOffer.Add(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterOfferController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterOffer.Find(id);
            MasterOfferModel model = new MasterOfferModel();
            
            model.IsActive = data.IsActive;
            model.MasterOfferId = data.MasterOfferId;
            model.MasterOfferTitle = data.MasterOfferTitle;
            model.MasterOfferDesc = data.MasterOfferDesc;
            model.MasterOfferBreef = data.MasterOfferBreef;
            model.MasterOfferImageUrl = data.MasterOfferImageUrl;
            return View(model);
        }

        // POST: MasterOfferController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterOfferModel collection)
        {
            try
            {
                string ImageName = SaveImage(collection.File);
                if (collection.File==null)
                {
                    ImageName = collection.MasterOfferImageUrl;
                }
                MasterOffer model = new MasterOffer();
                model.EditDate = DateTime.Now;
                model.EditUser = User.Identity.Name;
                model.IsActive = collection.IsActive;
                model.MasterOfferId = collection.MasterOfferId;
                model.MasterOfferTitle = collection.MasterOfferTitle;
                model.MasterOfferDesc = collection.MasterOfferDesc;
                model.MasterOfferBreef = collection.MasterOfferBreef;
                model.MasterOfferImageUrl = ImageName;
                MasterOffer.Update(id, model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterOfferController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = MasterOffer.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterOffer.Delete(id, data);
            return RedirectToAction(nameof(Index));
        }

        // POST: MasterOfferController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, MasterOffer collection)
        //{
        //    try
        //    {
        //        collection.EditDate = DateTime.Now;
        //        collection.EditUser = User.Identity.Name;
        //        MasterOffer.Delete(id, collection); 
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        public ActionResult Active(int id)
        {
            var data = MasterOffer.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterOffer.Active(id, data);
            return RedirectToAction(nameof(Index));
        }
        string SaveImage(IFormFile file)
        {
            string ImageName = "";
            if (file != null)
            {
                string Filepath = Path.Combine(Host.WebRootPath, "Images/MasterOffer");
                FileInfo fil = new FileInfo(file.FileName);
                ImageName = "Image_" + Guid.NewGuid() + fil.Extension;
                string FullPath = Path.Combine(Filepath, ImageName);
                file.CopyTo(new FileStream(FullPath, FileMode.Create));
            }
            return ImageName;
        }
    }
}
