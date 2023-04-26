using Microsoft.AspNetCore.Mvc;
using Restaurant.Models.Repositories;
using Restaurant.Models;
using Restaurant.ViewModels;
using System.Linq;
using System;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        public IRepository<MasterMenu> MasterMenu { get; }
        public IRepository<MasterSlider> MasterSlider { get; }
        public IRepository<SystemSetting> SystemSetting { get; }
        public IRepository<MasterSocialMedium> MasterSocialMedium { get; }
        public IRepository<MasterItemMenu> MasterItemMenu { get; }
        public IRepository<MasterCategoryMenu> MasterCategoryMenu { get; }
        public IRepository<MasterContactUsInformation> MasterContactUsInformation { get; }
        public IRepository<MasterOffer> MasterOffer { get; }
        public IRepository<MasterService> MasterService { get; }
        public IRepository<MasterPartner> MasterPartner { get; }
        public IRepository<TransactionBookTable> TransactionBookTable { get; }
        public IRepository<TransactionContactU> TransactionContactU { get; }
        public IRepository<TransactionNewsletter> TransactionNewsletter { get; }
        public IRepository<MasterWorkingHour> MasterWorkingHour { get; }
        public IRepository<breadcrumb_area> Breadcrumb_Area { get; }

        public HomeController(IRepository<MasterMenu> _MasterMenu, IRepository<MasterSlider> _MasterSlider, IRepository<SystemSetting> _SystemSetting,
            IRepository<MasterSocialMedium> _MasterSocialMedium, IRepository<MasterItemMenu> _MasterItemMenu, IRepository<MasterCategoryMenu> _MasterCategoryMenu,
            IRepository<MasterContactUsInformation> _MasterContactUsInformation, IRepository<MasterOffer> _MasterOffer, IRepository<MasterService> _MasterService,
            IRepository<MasterPartner> _MasterPartner, IRepository<TransactionBookTable> _TransactionBookTable, IRepository<TransactionContactU> _TransactionContactU, IRepository<TransactionNewsletter> _TransactionNewsletter,
            IRepository<MasterWorkingHour> _MasterWorkingHour, IRepository<breadcrumb_area> _breadcrumb_area)
        {
            MasterMenu = _MasterMenu;
            MasterSlider = _MasterSlider;
            SystemSetting = _SystemSetting;
            MasterSocialMedium = _MasterSocialMedium;
            MasterItemMenu = _MasterItemMenu;
            MasterCategoryMenu = _MasterCategoryMenu;
            MasterContactUsInformation = _MasterContactUsInformation;
            MasterOffer = _MasterOffer;
            MasterService = _MasterService;
            MasterPartner = _MasterPartner;
            TransactionBookTable = _TransactionBookTable;
            TransactionContactU = _TransactionContactU;
            TransactionNewsletter = _TransactionNewsletter;
            MasterWorkingHour = _MasterWorkingHour;
            Breadcrumb_Area = _breadcrumb_area;
        }


        public IActionResult Index()
        {
            HomeModel model = new HomeModel();
            model.MasterMenu = MasterMenu.ViewFrontClinet().ToList();
            model.MasterSlider = MasterSlider.ViewFrontClinet().ToList();
            model.MasterItemMenu = MasterItemMenu.ViewFrontClinet().ToList();
            model.SystemSetting = SystemSetting.ViewFrontClinet().SingleOrDefault();
            model.TransactionBookTable = TransactionBookTable.ViewFrontClinet().SingleOrDefault();
            model.MasterOffer = MasterOffer.ViewFrontClinet().SingleOrDefault();
            model.MasterContactUsInformation = MasterContactUsInformation.ViewFrontClinet().ToList();
            model.MasterPartner = MasterPartner.ViewFrontClinet().ToList();
            model.MasterWorkingHour = MasterWorkingHour.ViewFrontClinet().ToList();
            model.MasterSocialMedium = MasterSocialMedium.ViewFrontClinet().ToList();
            model.TransactionNewsletter = TransactionNewsletter.ViewFrontClinet().SingleOrDefault();
            model.breadcrumb_area=Breadcrumb_Area.ViewFrontClinet().ToList();

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BookTable(HomeModel collection)
        {
            try
            {

                if (collection.TransactionBookTable.TransactionBookTableEmail == null || collection.TransactionBookTable.TransactionBookTableMobileNumber == null)
                {

                    ModelState.AddModelError("", "Enter Email and Phone Number");
                    HomeModel model = new HomeModel();
                    model.MasterMenu = MasterMenu.ViewFrontClinet().ToList();
                    model.MasterSlider = MasterSlider.ViewFrontClinet().ToList();
                    model.MasterItemMenu = MasterItemMenu.ViewFrontClinet().ToList();
                    model.SystemSetting = SystemSetting.ViewFrontClinet().SingleOrDefault();
                    model.TransactionBookTable = TransactionBookTable.ViewFrontClinet().SingleOrDefault();
                    model.MasterOffer = MasterOffer.ViewFrontClinet().SingleOrDefault();
                    model.MasterContactUsInformation = MasterContactUsInformation.ViewFrontClinet().ToList();
                    model.MasterPartner = MasterPartner.ViewFrontClinet().ToList();
                    model.MasterSocialMedium = MasterSocialMedium.ViewFrontClinet().ToList();
                    model.MasterWorkingHour = MasterWorkingHour.ViewFrontClinet().ToList();
                    return View("Index", model);
                }
                else
                {
                    TransactionBookTable.Add(collection.TransactionBookTable);
                    return RedirectToAction(nameof(Index));

                }
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Newsletter(string TransactionNewsletterEmail,string viewName)
        {
            TransactionNewsletter transactionNewsletter = new TransactionNewsletter()
            {
                TransactionNewsletterEmail=TransactionNewsletterEmail
            };
            TransactionNewsletter.Add(transactionNewsletter);
            //return RedirectToAction(viewName,"Home");
            return RedirectToAction(nameof(Index));


            //try
            //{

            //    if (collection.TransactionNewsletter.TransactionNewsletterEmail == null )
            //    {

            //        ModelState.AddModelError("", "Enter Email ");
            //        HomeModel model = new HomeModel();
            //        model.MasterMenu = MasterMenu.ViewFrontClinet().ToList();
            //        model.MasterSlider = MasterSlider.ViewFrontClinet().ToList();
            //        model.MasterItemMenu = MasterItemMenu.ViewFrontClinet().ToList();
            //        model.SystemSetting = SystemSetting.ViewFrontClinet().SingleOrDefault();
            //        model.TransactionBookTable = TransactionBookTable.ViewFrontClinet().SingleOrDefault();
            //        model.MasterOffer = MasterOffer.ViewFrontClinet().SingleOrDefault();
            //        model.MasterContactUsInformation = MasterContactUsInformation.ViewFrontClinet().ToList();
            //        model.MasterPartner = MasterPartner.ViewFrontClinet().ToList();
            //        model.MasterSocialMedium = MasterSocialMedium.ViewFrontClinet().ToList();
            //        model.MasterWorkingHour = MasterWorkingHour.ViewFrontClinet().ToList();
            //        return View("Index", model);
            //    }
            //    else
            //    {
            //        TransactionNewsletter.Add(collection.TransactionNewsletter);
            //        return RedirectToAction("Index");

            //    }

            //    //TransactionNewsletter model = new TransactionNewsletter();
            //    //model.TransactionNewsletterId=collection.TransactionNewsletter.TransactionNewsletterId;
            //    //model.TransactionNewsletterEmail = collection.TransactionNewsletter.TransactionNewsletterEmail;
            //    //TransactionNewsletter.Add(model);

            //    //return RedirectToAction(nameof(Index));

            //}
            //catch
            //{
            //    return View();
            //}
        }
        [HttpPost]

        public ActionResult Contact(string TransactionContactUEmail,string TransactionContactUSubject, string TransactionContactUMessage,string TransactionContactUFullName, string viewName)
        {
            TransactionContactU transactionContactU = new TransactionContactU()
            {
                TransactionContactUFullName=TransactionContactUFullName,
                TransactionContactUEmail = TransactionContactUEmail,
                TransactionContactUSubject = TransactionContactUSubject,
                TransactionContactUMessage = TransactionContactUMessage
            };
            TransactionContactU.Add(transactionContactU);
            return RedirectToAction(nameof(Contactus));



            //try
            //{

            //    TransactionContactU model = new TransactionContactU();
            //    model.TransactionContactUId=collection.TransactionContactU.TransactionContactUId;
            //    model.TransactionContactUEmail = collection.TransactionContactU.TransactionContactUEmail;
            //    model.TransactionContactUSubject = collection.TransactionContactU.TransactionContactUSubject;
            //    model.TransactionContactUMessage=collection.TransactionContactU.TransactionContactUMessage;

            //    TransactionContactU.Add(model);

            //    return RedirectToAction("Contactus");

            //}
            //catch
            //{
            //    return View();
            //}
        }
        public IActionResult About()
        {
            HomeModel model = new HomeModel();
            model.MasterMenu = MasterMenu.ViewFrontClinet().ToList();
            model.SystemSetting = SystemSetting.ViewFrontClinet().SingleOrDefault();
            model.MasterService = MasterService.ViewFrontClinet().ToList();
            model.MasterSocialMedium = MasterSocialMedium.ViewFrontClinet().ToList();
            model.MasterWorkingHour = MasterWorkingHour.ViewFrontClinet().ToList();
            model.TransactionNewsletter = TransactionNewsletter.ViewFrontClinet().SingleOrDefault();

            model.MasterService = MasterService.ViewFrontClinet().ToList();

            return View(model);
        }
        public IActionResult Menu()
        {
            HomeModel model = new HomeModel();
            model.MasterMenu = MasterMenu.ViewFrontClinet().ToList();
            model.MasterItemMenu = MasterItemMenu.ViewFrontClinet().Where(x => x.MasterCategoryMenuId == x.MasterCategoryMenu.MasterCategoryMenuId).ToList();
            model.MasterCategoryMenu=MasterCategoryMenu.ViewFrontClinet().ToList();
            model.MasterSocialMedium = MasterSocialMedium.ViewFrontClinet().ToList();
            model.MasterWorkingHour = MasterWorkingHour.ViewFrontClinet().ToList();
            model.TransactionNewsletter = TransactionNewsletter.ViewFrontClinet().SingleOrDefault();

            model.MasterPartner = MasterPartner.ViewFrontClinet().ToList();
            model.SystemSetting = SystemSetting.ViewFrontClinet().SingleOrDefault();

            return View(model);
        }
        public IActionResult Contactus()
        {
            HomeModel model = new HomeModel();
            model.MasterMenu = MasterMenu.ViewFrontClinet().ToList();
            model.MasterSocialMedium = MasterSocialMedium.ViewFrontClinet().ToList();
            model.MasterWorkingHour = MasterWorkingHour.ViewFrontClinet().ToList();
            model.TransactionContactU=TransactionContactU.ViewFrontClinet().SingleOrDefault();
            model.TransactionNewsletter=TransactionNewsletter.ViewFrontClinet().SingleOrDefault();
            model.MasterPartner = MasterPartner.ViewFrontClinet().ToList();
            model.SystemSetting = SystemSetting.ViewFrontClinet().SingleOrDefault();

            return View(model);
        }
    }
}
