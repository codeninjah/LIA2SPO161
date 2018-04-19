using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LIA.Data.Services;
using LIA2Version3.Data.Entities;

namespace LIA.UI.Controllers
{
    public class MembershipController : Controller
    {
		private IDbReader _reader;

		public MembershipController(IDbReader reader)
		{
			_reader = reader;
		}

		public IActionResult Dashboard()
        {
			var products = _reader.Get<Product>().ToList();
            return View(products);
        }
    }
}