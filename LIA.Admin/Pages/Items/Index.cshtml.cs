﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIA.Data.Services;
using LIA2Version3.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LIA.Admin.Pages.Items
{
	[Authorize(Roles = "Admin")]
	public class IndexModel : PageModel
	{
		//public string text;
		IDbReader _db;
		public IList<Item> Item { get; set; }


		public IndexModel(IDbReader db)
		{
			//text = "Hello WOrld";
			_db = db;
		}

		public void OnGet()
		{
			//Item = _db.Get<Item>().ToList();
			Item = _db.GetWithIncludes<Item>().ToList();
		}
	}
}