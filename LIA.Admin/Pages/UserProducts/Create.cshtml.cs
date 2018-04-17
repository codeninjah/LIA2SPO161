using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIA2Version3.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LIA.Data.Services;

namespace LIA.Admin.Pages.UserProducts
{
	public class CreateModel : PageModel
	{
		private readonly IDbWriter _writer;
		private readonly IDbReader _reader;

		public CreateModel(IDbWriter writer, IDbReader reader)
		{
			_writer = writer;
			_reader = reader;
		}

		public void OnGet()
		{
			ViewData["Users"] = _reader.GetSelectList<User>("Id", "Email");
			ViewData["Products"] = _reader.GetSelectList<Product>("ProductId", "Name");
		}

		[BindProperty]
		public UserProduct UserProducts { get; set; }

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			try
			{
				var success = await _writer.AddAsync(UserProducts); //LÄGG TILL I SERVICEN

				if (success)
				{
					return RedirectToPage("./Index"); // Kan även läggas till i catch blocket nedan
				}
			}
			catch { }
			ViewData["Users"] = _reader.GetSelectList<User>("Id", "Email");
			ViewData["Products"] = _reader.GetSelectList<Product>("ProductId", "Name");

			return Page();
		}

	}
}