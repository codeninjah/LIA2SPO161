using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIA.Data.Services;
using LIA2Version3.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LIA.Admin.Pages.Products
{
	public class IndexModel : PageModel
	{
		//public string text;
		IDbReader _db;
		public IList<Product> Product { get; set; }


		public IndexModel(IDbReader db)
		{
			//text = "Hello WOrld";
			_db = db;
		}

		public void OnGet()
		{
			Product = _db.Get<Product>().ToList();
		}
	}
}