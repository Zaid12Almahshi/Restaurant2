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
    public class MasterContactUsInformationController : Controller
    {
        public IRepository<MasterContactUsInformation> MasterContactUsInformation { get; }
        public IHostingEnvironment Host { get; }

        public MasterContactUsInformationController(IRepository<MasterContactUsInformation> _MasterContactUsInformation,IHostingEnvironment _Host)
        {
            MasterContactUsInformation = _MasterContactUsInformation;
            Host = _Host;
        }
        // GET: MasterContactUsInformationController
        public ActionResult Index()
        {

            return View(MasterContactUsInformation.View());
        }

        // GET: MasterContactUsInformationController/Details/5
        public ActionResult Details(int id)
        {

            return View(MasterContactUsInformation.Find(id));
        }

        // GET: MasterContactUsInformationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterContactUsInformationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterContactUsInformationModel collection)
        {
            try
            {
                string ImageName = SaveImage(collection.File);
                
                MasterContactUsInformation model=new MasterContactUsInformation();
                model.CreateDate = DateTime.Now;
                model.CreateUser = User.Identity.Name;
                model.IsActive = collection.IsActive;
                model.MasterContactUsInformationId = collection.MasterContactUsInformationId;
                model.MasterContactUsInformationIdesc = collection.MasterContactUsInformationIdesc;
                model.MasterContactUsInformationRedirect = collection.MasterContactUsInformationRedirect;
                model.MasterContactUsInformationTitle = collection.MasterContactUsInformationTitle;
                model.MasterContactUsInformationImageUrl = ImageName;
                    
                MasterContactUsInformation.Add(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterContactUsInformationController/Edit/5
        public ActionResult Edit(int id)
        {
            
            
            var data=MasterContactUsInformation.Find(id);
            MasterContactUsInformationModel model = new MasterContactUsInformationModel();

            model.IsActive = data.IsActive;
            model.MasterContactUsInformationId = data.MasterContactUsInformationId;
            model.MasterContactUsInformationIdesc = data.MasterContactUsInformationIdesc;
            model.MasterContactUsInformationRedirect = data.MasterContactUsInformationRedirect;
            model.MasterContactUsInformationImageUrl = data.MasterContactUsInformationImageUrl;
            model.MasterContactUsInformationTitle = data.MasterContactUsInformationTitle;
            return View(model);
        }

        // POST: MasterContactUsInformationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterContactUsInformationModel collection)
        {
            try
            {
                string ImageName = SaveImage(collection.File);
                if (collection.File == null)
                {
                    ImageName = collection.MasterContactUsInformationImageUrl;
                }
                MasterContactUsInformation model = new MasterContactUsInformation();
                model.EditDate = DateTime.Now;
                model.EditUser = User.Identity.Name;
                model.IsActive = collection.IsActive;
                model.MasterContactUsInformationId = collection.MasterContactUsInformationId;
                model.MasterContactUsInformationIdesc = collection.MasterContactUsInformationIdesc;
                model.MasterContactUsInformationRedirect = collection.MasterContactUsInformationRedirect;
                model.MasterContactUsInformationTitle = collection.MasterContactUsInformationTitle;
                model.MasterContactUsInformationImageUrl = ImageName;
                MasterContactUsInformation.Update(id, model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterContactUsInformationController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = MasterContactUsInformation.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterContactUsInformation.Delete(id,data);
            return RedirectToAction(nameof(Index));
        }

        // POST: MasterContactUsInformationController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, MasterContactUsInformation collection)
        //{
        //    try
        //    {
        //       collection.EditDate = DateTime.Now;
        //        collection.EditUser = User.Identity.Name;
        //        MasterContactUsInformation.Delete(id, collection);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        public ActionResult Active(int id)
        {
            var data=MasterContactUsInformation.Find(id);
            data.EditDate = DateTime.Now;
            data.EditUser = User.Identity.Name;
            MasterContactUsInformation.Active(id, data);
            return RedirectToAction(nameof(Index));
        }
        string SaveImage(IFormFile file)
        {
            string ImageName = "";
            if (file != null)
            {
                string Filepath = Path.Combine(Host.WebRootPath, "Images/MasterContactUsInformation");
                FileInfo fil = new FileInfo(file.FileName);
                ImageName = "Image_" + Guid.NewGuid() + fil.Extension;
                string FullPath = Path.Combine(Filepath, ImageName);
                file.CopyTo(new FileStream(FullPath, FileMode.Create));
            }
            return ImageName;
        }
    }
}
