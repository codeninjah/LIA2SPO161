using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LIA.Data.Data;
using LIA2Version3.Data.Entities;
using Microsoft.AspNetCore.Authorization;

namespace LIA.Admin.Pages.ItemTypes
{
	[Authorize(Roles = "Admin")]
	public class EditModel : PageModel
	{
		private readonly LIA.Data.Services.IDbWriter _writer;
		private readonly LIA.Data.Services.IDbReader _reader;

		public EditModel(LIA.Data.Services.IDbReader reader, LIA.Data.Services.IDbWriter writer)
		{
			_reader = reader;
			_writer = writer;
		}

		[BindProperty]
		public ItemType ItemType { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			ItemType = await _reader.Get<ItemType>((int)id);

			if (ItemType == null)
			{
				return NotFound();
			}
			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			try
			{
				await _writer.UpdateAsync(ItemType);
				//await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				//if (!ItemTypeExists(ItemType.Id))
				//{
				//	return NotFound();
				//}
				//else
				//{
					throw;
				//}
			}

			return RedirectToPage("./Index");
		}

		//private bool ItemTypeExists(int id)
		//
		//	return _reader.Get<ItemType>(id);
		//}
	}
}
