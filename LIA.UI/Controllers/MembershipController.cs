using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LIA.UI.Controllers
{
    public class MembershipController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}