using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace ISD.Areas.Admin.Models
{
    public class PagesData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string PageUrl { get; set; }       
        [Required]  
        [DefaultValue("")]
        public string PageTitle { get; set; }
        [Required]
        [DefaultValue("")]
        public string Keywords { get; set; }
        [Required]
        [DefaultValue("")]
        public string Descriptions { get; set; }
        [Required]
        [AllowHtml]
        [DefaultValue("")]
        [DataType(DataType.MultilineText)]
        public string PageContent { get; set; }

    }

    public class PageDataMethods
    {
        public PagesData getPageInfo(string url)
        { 
            dbContext db=new dbContext();
            var data = db.pageDataList.Where(i => i.PageUrl == url).SingleOrDefault();
            return data;
        
        }
    }

   
}