using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIA.Data.Data.Entities;
using LIA.Data.Services;
using LIA2Version3.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LIA.Admin.Pages.Authors
{
	[Authorize(Roles = "Admin")]
	public class IndexModel : PageModel
	{
		//public string text;
		IDbReader _db;
		public IList<Author> Authors { get; set; }


		public IndexModel(IDbReader db)
		{
			//text = "Hello WOrld";
			_db = db;
		}

		public void OnGet()
		{
			//Item = _db.Get<Item>().ToList();
			Authors = _db.GetWithIncludes<Author>().ToList();
		}
	}
}