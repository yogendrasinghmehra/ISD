using ISD.Areas.Admin.Models;
using ISD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISD.ViewModels.Home
{
    public class IndexViewModel
    {
        public PagesData pagesData { get; set; }

    }

    public class AboutViewModel
    {
        public PagesData pagesData { get; set; }

    }

    public class ServicesViewModel
    {
        public PagesData pagesData { get; set; }

    }

    public class ContactViewModel
    {
        public PagesData pagesData { get; set; }
        public CustomerQuery customerQuery { get; set; }

    }

    public class DrawingsViewModel
    {
        public PagesData pagesData { get; set; }
        public List<DrawingsType> drawingsTypeList { get; set; }
        public List<Drawing> drawingsList { get; set; }

    }


    public class ModelsViewModel
    {
        public PagesData pagesData { get; set; }
        public List<SampleModels> modelsList { get; set; }

    }
}