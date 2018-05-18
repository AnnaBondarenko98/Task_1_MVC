using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogAsp.Models.Models;

namespace Task1ASP.Areas.Admin.Models
{
    public class CheckModel
    {
        public Tag Tag { get; set; }
        public bool Checked { get; set; }
    }
}