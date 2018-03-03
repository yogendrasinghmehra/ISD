using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Web;

namespace ISD.Models
{
    public class Carrier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Invalid Email Address.")]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string DateOfBirth { get; set; }

        [Required]
        [Phone(ErrorMessage ="Invalid Phone No.")]
        public string ContactNo { get; set; }

        [Required]
        [StringLength(50)]
        public string Experience { get; set; }

        [Required]
        [StringLength(150)]
        public string Education { get; set; }
        
        public string  ResumeUrl { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }


        public string SaveResume(HttpPostedFileBase file)
        {
            string[] allowedExtention = new string[] { ".pdf", ".docx", ".doc" };
            string finaleImageUrl = string.Empty;
            string imageExtention = Path.GetExtension(file.FileName);
            Guid id = Guid.NewGuid();
            if (allowedExtention.Contains(imageExtention))
            {
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Resumes")))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Resumes"));
                }


                //var savingPath = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/DrawingImages/LargeImages/"), id + imageExtention);
                var savingPath = Path.Combine(HttpContext.Current.Server.MapPath("~/Resumes"), Guid.NewGuid().ToString()+ Path.GetExtension(file.FileName));
                file.SaveAs(savingPath);
                finaleImageUrl = string.Concat("Resumes/", Guid.NewGuid().ToString() + Path.GetExtension(file.FileName));
            }
            return finaleImageUrl;
        }



    }
}