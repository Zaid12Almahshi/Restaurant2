using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Restaurant.ViewModels;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MasterSliderController : Controller
    {
        public IRepository<MasterSlider> MasterSlider { get; }
        public IHostingEnvironment Host { get; }

        public MasterSliderController(IRepository<MasterSlider> _MasterSlider,IHostingEnvironment _Host )
        {
            MasterSlider = _MasterSlider;
            Host = _Host;
        }
        // GET: MasterSliderController
        public ActionResult Index()
        {
            return View(MasterSlider.View());
        }

        // GET: MasterSliderController/Details/5
        public ActionResult Details(int id)
        {
            return View(MasterSlider.Find(id));
        }

        // GET: MasterSliderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterSliderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterSliderModel collection)
        {
            try
            {
                string ImageName = SaveImage(collection.File);
                MasterSlider model=new MasterSlider();

                model.CreateDate = DateTime.Now;
                model.CreateUser = User.Identity.Name;
                model.MasterSliderDesc = collection.MasterSliderDesc;
                model.MasterSliderBreef= collection.MasterSliderBreef;  
                model.MasterSliderTitle= collection.MasterSliderTitle;
                model.MasterSliderId= collection.MasterSliderId;
                model.MasterSliderUrl = ImageName;
                MasterSlider.Add(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSliderController/Edit/5
        public ActionResult Edit(int id)
        {
            var data=MasterSlider.Find(id);
            MasterSliderModel model=new MasterSliderModel();
            model.MasterSliderTitle= data.MasterSliderTitle;
            model.MasterSliderUrl= data.MasterSliderUrl;
            model.MasterSliderDesc= data.MasterSliderDesc;
            model.MasterSliderId = data.MasterSliderId;
            model.MasterSliderBreef = data.MasterSliderBreef;
            return View(data);
        }

        // POST: MasterSliderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterSliderModel collection)
        {
            try
            {
                string ImageName = SaveImage(collection.File);
                if (collection.File==null)
                {
                    ImageName = collection.MasterSliderUrl;
                }
                MasterSlider model=new MasterSlider();

                model.EditDate = DateTime.Now;
                model.EditUser = User.Identity.Name;
                model.MasterSliderDesc = collection.MasterSliderDesc;
                model.MasterSliderBreef = collection.MasterSliderBreef;
                model.MasterSliderTitle = collection.MasterSliderTitle;
                model.MasterSliderId = collection.MasterSliderId;
                model.MasterSliderUrl = ImageName;
                MasterSlider.Update(id, model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSliderController/Delete/5
        public ActionResult Delete(int id)
        {
            var data= MasterSlider.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterSlider.Delete(id, data);
            return RedirectToAction(nameof(Index));
        }

        // POST: MasterSliderController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, MasterSlider collection)
        //{
        //    try
        //    {
        //        collection.EditDate = DateTime.Now;
        //        collection.EditUser = User.Identity.Name;
        //        MasterSlider.Delete(id,collection); 
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        public ActionResult Active(int id)
        {
            var data = MasterSlider.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterSlider.Active(id, data);
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
