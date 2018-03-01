using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ISD.Areas.Admin.Models
{
    public class AdminLogin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdminId { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }


    }

    public class ChangePassword
    {
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword")]
        public string ConfirmPassword { get; set; }

    }
}