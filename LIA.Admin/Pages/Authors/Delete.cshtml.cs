using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIA2Version3.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using LIA.Data.Data.Entities;

namespace LIA.Admin.Pages.Authors
{
	[Authorize(Roles = "Admin")]
	public class DeleteModel : PageModel
	{
		//public IActionResult OnGet()
		//{
		//	return Page();
		//}

		private readonly LIA.Data.Services.IDbWriter _db;
		private readonly LIA.Data.Services.IDbReader _reader;

		public DeleteModel(LIA.Data.Services.IDbWriter db, LIA.Data.Services.IDbReader reader)
		{
			_db = db;
			_reader = reader;
		}


		//TILLLAGD
		[BindProperty]
		public Author Author { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Author = await _reader.Get<Author>((int)id);
			if (Author == null)
			{
				return NotFound();
			}
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Author = await _reader.Get<Author>((int)id);

			if (Author != null)
			{
				await _db.Remove<Author>(Author);
			}

			return RedirectToPage("./Index");
		}

	}

}
