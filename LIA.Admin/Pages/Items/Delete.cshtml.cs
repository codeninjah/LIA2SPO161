using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIA2Version3.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace LIA.Admin.Pages.Items
{
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
		public Item Item { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Item = await _reader.Get<Item>((int)id);
			if (Item == null)
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

			Item = await _reader.Get<Item>((int)id);

			if (Item != null)
			{
				await _db.Remove<Item>(Item);
			}

			return RedirectToPage("./Index");
		}

	}

	}
