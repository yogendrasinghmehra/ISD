using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace ISD.Areas.Admin.Models
{
    public class Drawing
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DrawingId { get; set; }


        [Required]
        public int DrawingTypeId { get; set; }
        public DrawingsType drawingsType { get; set; }

        [StringLength(100)]
        [Required]
        public string Name { get; set; }        
        public string LargeImageUrl { get; set; }
        public bool IsEnabled { get; set; } 
        
        [NotMapped]
        public List<DrawingsType> drawingList { get; set; }
        
    }

    public class DrawingMethods
    {
        public string SaveLargeImage(HttpPostedFileBase file,string DrawingType)
        {
            string[] allowedExtention = new string[] { ".jpg", ".png", ".JPEG", ".jpeg" };
            string finaleImageUrl = string.Empty;
            string imageExtention = Path.GetExtension(file.FileName);
            Guid id = Guid.NewGuid();
            if (allowedExtention.Contains(imageExtention))
            {
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Images/DrawingImages/"+ DrawingType + "/"))) 
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Images/DrawingImages/" + DrawingType + "/"));
                }


                //var savingPath = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/DrawingImages/LargeImages/"), id + imageExtention);
                var savingPath = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/DrawingImages/" + DrawingType + "/"), file.FileName);
                file.SaveAs(savingPath);
                finaleImageUrl = string.Concat("/Images/DrawingImages/" + DrawingType + "/", file.FileName);
            }
            return finaleImageUrl;
        }
       
    
    }
}