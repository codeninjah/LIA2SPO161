using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIA2Version3.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LIA.Admin.Pages.Items
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
			ViewData["ItemTypes"] = _reader.GetSelectList<ItemType>("Id", "Name");
			//ViewData["Products"] = _reader.GetSelectList<Product>("Id", "Name");
		}

		[BindProperty]
		public Item Items { get; set; }

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			await _db.AddAsync(Items); //LÄGG TILL I SERVICEN
			return RedirectToPage("./Index");
		}

	}
}