using ISD.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISD.ViewModels.Home;
using ISD.Models;

namespace ISD.Controllers
{
   
    public class HomeController : Controller
    {
       private PageDataMethods getData = new PageDataMethods();
        private dbContext db = new dbContext();
        public ActionResult Index()
        {
            string url = HttpContext.Request.Url.AbsoluteUri;

            IndexViewModel viewModel = new IndexViewModel();

            viewModel.pagesData= getData.getPageInfo(url);
          
            return View(viewModel);                      
        }

        [Route("Services")]
        public ActionResult Services()
        {
            string url = HttpContext.Request.Url.AbsoluteUri;
            ServicesViewModel viewModel = new ServicesViewModel();
            viewModel.pagesData = getData.getPageInfo(url);
            return View(viewModel);
        }

        [Route("About")]
        public ActionResult About()
        {
            string url = HttpContext.Request.Url.AbsoluteUri;

            AboutViewModel viewModel = new AboutViewModel();

            viewModel.pagesData = getData.getPageInfo(url);
            return View(viewModel);           
        }
        [Route("Contact")]
        public ActionResult Contact()
        {
            string url = HttpContext.Request.Url.AbsoluteUri;

            ContactViewModel viewModel = new ContactViewModel();

            viewModel.pagesData = getData.getPageInfo(url);

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
            drawingsViewModel.pagesData = getData.getPageInfo(HttpContext.Request.Url.AbsoluteUri);
            drawingsViewModel.drawingsList = db.drawings.ToList();
            return View(drawingsViewModel);
        }

        [Route("SampleModels")]
        public ActionResult SampleModels()
        {
            ModelsViewModel modelsViewModel = new ModelsViewModel();
            modelsViewModel.pagesData = getData.getPageInfo(HttpContext.Request.Url.AbsoluteUri);
            modelsViewModel.modelsList = db.models.ToList();
            return View(modelsViewModel);
        }

        [HttpPost]
        public ActionResult AddMail(ContactViewModel query)
        {
            if(ModelState.IsValid)
            {
                db.customerQuery.Add(query.customerQuery);
                db.SaveChanges();
                ISDServices services = new ISDServices();
               // services.SendMailToAdmin("User Query", query.customerQuery.Email);
                
             
            }
            TempData["statusMsg"] = "Query Added Successfully";
            return RedirectToAction("Contact");
        }

    }
}