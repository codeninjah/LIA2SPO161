using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIA2Version3.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace LIA.Admin.Pages.ItemTypes
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
		public ItemType ItemType { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			ItemType = await _reader.Get<ItemType>((int) id);
			if (ItemType == null)
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

			ItemType = await _reader.Get<ItemType>((int) id);

			if (ItemType != null)
			{
				await _db.Remove<ItemType>(ItemType);
			}

			return RedirectToPage("./Index");
		}

	}
}