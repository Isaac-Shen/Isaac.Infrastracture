using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Isaac.SampleMvc.Models
{
    public class StrongTypeLinkSample
    {
        [Required(ErrorMessage = "You should specify who are you")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You should specify whether you go or not")]
        public bool? WillAttend { get; set; }
    }
}