using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ISD.Areas.Admin.Models
{
    public class DrawingsType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DrawingTypeId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
    }
}