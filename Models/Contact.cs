﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ISD.Models
{
    public class CustomerQuery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string Email { get; set; }
        [Required]
        [Phone(ErrorMessage ="Invalid Phone No")]
        public string PhoneNo { get; set; }
        [Required]
        [StringLength(200)]
        public string Message { get; set; }       
        public DateTime createdDate { get; set; }



    }
}