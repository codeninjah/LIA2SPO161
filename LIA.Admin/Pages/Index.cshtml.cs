using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIA.Data.Services;
using LIA2Version3.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LIA.Admin.Pages
{
	[Authorize(Roles = "Admin")]
	public class IndexModel : PageModel
	{
		//public string text;
		IDbReader _db;

		//public int item;
		//public int product;

		public IndexModel(IDbReader db)
		{
			//text = "Hello WOrld";
			_db = db;
		}


		public void OnGet()
		{
			var counter = Count();
			ViewData["itemCount"] = counter.itemCount;
			ViewData["itemTypeCount"] = counter.itemTypeCount;
			ViewData["listItemCount"] = counter.listItemCount;
			ViewData["productCount"] = counter.productCount;
			ViewData["userProductCount"] = counter.userProductCount;
		}


		(int itemCount, int itemTypeCount, int listItemCount, int productCount, int userProductCount) Count()
			{
			return (itemCount: _db.Get<Item>().Count(),
				itemTypeCount: _db.Get<ItemType>().Count(),
				listItemCount: _db.Get<ListItem>().Count(),
				productCount: _db.Get<Product>().Count(),
				userProductCount: _db.Get<UserProduct>().Count());
			}

	}
}
