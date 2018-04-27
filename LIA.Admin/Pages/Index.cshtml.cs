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
		public List<Item> items;
		public List<ItemType> itemtypes;
		public List<ListItem> listitems;
		public List<Product> products;
		public List<UserProduct> userproducts;

		//public int item;
		//public int product;

		public IndexModel(IDbReader db)
		{
			//text = "Hello WOrld";
			_db = db;
		}

		//public void ItemCount()
		//{
		//	item = _db.Get<Item>().ToList().Count();
		//}

		//public void ProductCount()
		//{
		//	product = _db.Get<Product>().ToList().Count();
		//}

		(int itemcount, int itemtypecount, int listitemcount, int productcount, int userproductcount) Count()
			{
			return (itemcount: _db.Get<Product>().Count(),
				itemtypecount: _db.Get<ItemType>().Count(),
				listitemcount: _db.Get<ListItem>().Count(),
				productcount: _db.Get<Product>().Count(),
				userproductcount: _db.Get<UserProduct>().Count());
			}

	}
}
