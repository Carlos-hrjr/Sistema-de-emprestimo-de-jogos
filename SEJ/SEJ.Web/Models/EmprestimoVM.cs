using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEJ.Web.Models
{
    public class EmprestimoVM
    {
        public IEnumerable<SelectListItem> Jogos { get; set; }
        public IEnumerable<SelectListItem> Amigos { get; set; }
    }
}