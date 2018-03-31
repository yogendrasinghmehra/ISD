using ISD.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISD.ViewModels.Home;
using ISD.Models;
using System.Net.Mail;
using System.Net;

namespace ISD.Controllers
{
   
    public class HomeController : Controller
    {
       private PageDataMethods getData = new PageDataMethods();
        private dbContext db = new dbContext();
        public ActionResult Index()
        {           
            IndexViewModel viewModel = new IndexViewModel();
            viewModel.pagesData= getData.getPageInfo(Request.Path);
          
            return View(viewModel);                      
        }

        [Route("Services")]
        public ActionResult Services()
        {            
            ServicesViewModel viewModel = new ServicesViewModel();
            viewModel.pagesData = getData.getPageInfo(Request.Path);
            return View(viewModel);
        }

        [Route("About")]
        public ActionResult About()
        {
            

            AboutViewModel viewModel = new AboutViewModel();

            viewModel.pagesData = getData.getPageInfo(Request.Path);
            return View(viewModel);           
        }
        [Route("Contact")]
        public ActionResult Contact()
        {
            

            ContactViewModel viewModel = new ContactViewModel();

            viewModel.pagesData = getData.getPageInfo(Request.Path);

            if(TempData["statusMsg"]!=null)
                {
                ViewBag.status = TempData["statusMsg"];
            }

            return View(viewModel);            
        }

        [Route("Drawings")]
        public ActionResult Drawings()
        {
            DrawingsViewModel drawingsViewModel = new DrawingsViewModel();

            drawingsViewModel.pagesData = getData.getPageInfo(Request.Path);
            drawingsViewModel.drawingsList = db.drawings.ToList();
            drawingsViewModel.drawingsTypeList = db.drawingTypes.ToList();

            return View(drawingsViewModel);
        }

        [Route("SampleModels")]
        public ActionResult SampleModels()
        {
            ModelsViewModel modelsViewModel = new ModelsViewModel();
            modelsViewModel.pagesData = getData.getPageInfo(Request.Path);
            modelsViewModel.modelsList = db.models.ToList();
            return View(modelsViewModel);
        }

        [Route("Career")]
        public ActionResult Career()
        {          
            ContactViewModel viewModel = new ContactViewModel();
            viewModel.pagesData = getData.getPageInfo(Request.Path);

            if (TempData["statusMsg"] != null)
            {
                ViewBag.status = TempData["statusMsg"];
            }

            return View();
        }

        [HttpPost]
        public ActionResult AddMail(ContactViewModel query)
        {
            if(ModelState.IsValid)
            {
                query.customerQuery.createdDate = DateTime.Now;
                db.customerQuery.Add(query.customerQuery);
                db.SaveChanges();
                ISDServices services = new ISDServices();               
               services.SendMailToAdmin("User Query", query.customerQuery);

            }
            TempData["statusMsg"] = "Query Added Successfully";
            return RedirectToAction("Contact");
        }

        [HttpPost]
        public ActionResult AddCarrier(Carrier query,HttpPostedFileBase resume)
        {
            if (ModelState.IsValid && resume!=null)
            {
                query.CreatedDate = DateTime.Now;
                query.ResumeUrl = query.SaveResume(resume);
                db.carrier.Add(query);
                db.SaveChanges();
                TempData["statusMsg"] = "Query Added Successfully";
            }
            else
            {
                TempData["statusMsg"] = "Something went wrong.";
            }          
            return RedirectToAction("Career");
        }


        [HttpGet]
        public JsonResult GetDrawingsByType(int typeId)
        {
            //var dd=db.drawings.Where(i=>i.)
            if(typeId==0)
            {
                return Json(db.drawings.ToList(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(db.drawings.Where(i => i.DrawingTypeId == typeId), JsonRequestBehavior.AllowGet);
            }
            
        }

    }
}