using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace ISD.Areas.Admin.Models
{
    public class SampleModels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModelId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }               
        public string LargeImageUrl { get; set; }        
        public bool IsEnabled { get; set; }               
        
    }


    public class SampleModelMethods
    {
        public string SaveLargeImage(HttpPostedFileBase file)
        {
            string[] allowedExtention = new string[] { ".jpg", ".png", ".JPEG", ".jpeg" };
            string finaleImageUrl = string.Empty;
            string imageExtention = Path.GetExtension(file.FileName);
            Guid id = Guid.NewGuid();
            if (allowedExtention.Contains(imageExtention))
            {
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Images/ModelImages/LargeImages/")))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Images/ModelImages/LargeImages/"));
                }

                var savingPath = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/ModelImages/LargeImages/"), file.FileName);
                file.SaveAs(savingPath);
                finaleImageUrl = string.Concat("/Images/ModelImages/LargeImages/",file.FileName);
            }
            return finaleImageUrl;
        }
       
    }
}