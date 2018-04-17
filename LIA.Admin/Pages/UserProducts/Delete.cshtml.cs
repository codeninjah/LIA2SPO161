using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIA2Version3.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace LIA.Admin.Pages.UserProducts
{
	public class DeleteModel : PageModel
	{
		//public IActionResult OnGet()
		//{
		//	return Page();
		//}

		private readonly LIA.Data.Services.IDbWriter _writer;
		private readonly LIA.Data.Services.IDbReader _reader;

		public DeleteModel(LIA.Data.Services.IDbWriter writer, LIA.Data.Services.IDbReader reader)
		{
			_writer = writer;
			_reader = reader;
		}


		//TILLLAGD
		[BindProperty]
		public UserProduct UserProduct { get; set; }

		public void  OnGet(string userid, int productid)
		{
			var test = _reader.Get(userid);
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			UserProduct = await _reader.Get<UserProduct>((int)id);

			if (UserProduct != null)
			{
				await _writer.Remove<UserProduct>(UserProduct);
			}

			return RedirectToPage("./Index");
		}

	}
}