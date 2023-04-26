using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repositories;
using Restaurant.Models;
using Restaurant.ViewModels;

using System.IO;
using System;
using Microsoft.AspNetCore.Hosting;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class breadcrumb_areaController : Controller
    {
        public IRepository<breadcrumb_area> Breadcrumb_Area { get; }
        public IHostingEnvironment Host { get; }

        public breadcrumb_areaController(IRepository<breadcrumb_area> _breadcrumb_area,IHostingEnvironment _Host)
        {
            Breadcrumb_Area = _breadcrumb_area;
            Host = _Host;
        }
        // GET: breadcrumb_areaController1
        public ActionResult Index()
        {
            return View(Breadcrumb_Area.View());
        }

        // GET: breadcrumb_areaController1/Details/5
        public ActionResult Details(int id)
        {

            return View(Breadcrumb_Area.Find(id));
        }

        // GET: breadcrumb_areaController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: breadcrumb_areaController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(breadcrumb_areaModel collection)
        {
            try
            {
                string ImageName = SaveImage(collection.File);
                breadcrumb_area model=new breadcrumb_area();
                model.CreateUser=User.Identity.Name;
                model.CreateDate=DateTime.Now;
                model.breadcrumb_areaId = collection.breadcrumb_areaId;
                model.breadcrumb_areaName = collection.breadcrumb_areaName;
                model.Price = collection.Price;
                model.Title=collection.Title;
                model.breadcrumb_areaUrlImage = ImageName;
                Breadcrumb_Area.Add(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: breadcrumb_areaController1/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Breadcrumb_Area.Find(id);
            breadcrumb_areaModel model =new  breadcrumb_areaModel();
            model.breadcrumb_areaId=data.breadcrumb_areaId;
            model.breadcrumb_areaName=data.breadcrumb_areaName;
            model.breadcrumb_areaUrlImage=data.breadcrumb_areaUrlImage;
            model.Price = data.Price;
            model.Title = data.Title;
            return View(model);
        }

        // POST: breadcrumb_areaController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, breadcrumb_areaModel collection)
        {
            try
            {
                string ImageName=SaveImage(collection.File);
                if (collection.File==null)
                {
                    ImageName = collection.breadcrumb_areaUrlImage;
                }
                breadcrumb_area model = new breadcrumb_area();
                model.breadcrumb_areaId=collection.breadcrumb_areaId;
                model.breadcrumb_areaUrlImage=collection.breadcrumb_areaUrlImage;
                model.breadcrumb_areaName = collection.breadcrumb_areaName;
                model.Price = collection.Price;
                model.Title = collection.Title;
                model.EditUser = User.Identity.Name;
                model.EditDate = DateTime.Now;
                Breadcrumb_Area.Update(id, model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: breadcrumb_areaController1/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Breadcrumb_Area.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            Breadcrumb_Area.Delete(id, data);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Active(int id)
        {
            var data = Breadcrumb_Area.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            Breadcrumb_Area.Active(id, data);
            return RedirectToAction(nameof(Index));
        }
        // POST: breadcrumb_areaController1/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        string SaveImage(IFormFile file)
        {
            string ImageName = "";
            if (file != null)
            {
                string Filepath = Path.Combine(Host.WebRootPath, "Images/breadcrumb_area");
                FileInfo fil = new FileInfo(file.FileName);
                ImageName = "Image_" + Guid.NewGuid() + fil.Extension;
                string FullPath = Path.Combine(Filepath, ImageName);
                file.CopyTo(new FileStream(FullPath, FileMode.Create));
            }
            return ImageName;
        }
    }
}
