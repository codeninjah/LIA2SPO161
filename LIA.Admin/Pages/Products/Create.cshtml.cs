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

namespace LIA.Admin.Pages.Products
{
	[Authorize(Roles = "Admin")]
	public class CreateModel : PageModel
	{
		public IActionResult OnGet()
		{
			ViewData["Authors"] = _reader.GetSelectList<Author>("Id", "Name");
			return Page();
		}

		private readonly LIA.Data.Services.IDbWriter _db;
		private readonly IDbReader _reader;

		public CreateModel(LIA.Data.Services.IDbWriter db, IDbReader reader)
		{
			_db = db;
			_reader = reader;
		}

		[BindProperty]
		public Product Products { get; set; }

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			await _db.AddAsync(Products); //LÄGG TILL I SERVICEN
			return RedirectToPage("./Index");
		}

	}
}