using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using LIA2Version3.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LIA.Admin.Pages.ListItems
{
	[Authorize(Roles = "Admin")]
	public class CreateModel : PageModel
	{
		
		private readonly LIA.Data.Services.IDbWriter _db;
		private readonly LIA.Data.Services.IDbReader _reader;

		public CreateModel(LIA.Data.Services.IDbWriter db, LIA.Data.Services.IDbReader reader)
		{
			_db = db;
			_reader = reader;
		}

		public void OnGet()
		{
			ViewData["Products"] = _reader.GetSelectList<Product>("Id", "Name");
			ViewData["Items"] = _reader.GetSelectList<Item>("Id", "Name");
		}


		[BindProperty]
		public ListItem ListItem { get; set; }

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			await _db.AddAsync(ListItem); //LÄGG TILL I SERVICEN
			return RedirectToPage("./Index");
		}

	}
}