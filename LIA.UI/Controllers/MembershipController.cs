using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LIA.Data.Services;
using LIA2Version3.Data.Entities;
using LIA.UI.Models.Membership;

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
			var model = new DashboardViewModel();
			model.Products = new List<List<Product>>();

			var products = _reader.Get<Product>();

			var numRows = products.Count() <= 3 ? 1 :
				products.Count() / 3;

			for (int i = 0; i <= numRows; i++)
			{
				model.Products.Add(products.Skip(i * 3).Take(3).ToList());
			}

			return View(model);
        }
    }
}