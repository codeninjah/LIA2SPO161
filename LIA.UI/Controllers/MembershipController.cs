using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LIA.Data.Services;
using LIA2Version3.Data.Entities;
using LIA.UI.Models.Membership;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace LIA.UI.Controllers
{
	[Authorize]
	public class MembershipController : Controller
    {
		private IDbReader _reader;
		private UserManager<User> _userManager;
		private SignInManager<User> _signInManager;
		private string userId;

		public MembershipController(IDbReader reader, UserManager<User> userManager, SignInManager<User> signInManager)
		{
			_reader = reader;
			_userManager = userManager;
			_signInManager = signInManager;
			 userId = _userManager.GetUserId(_signInManager.Context.User);
		}

		public IActionResult Dashboard()
        {			
			
			var model = new DashboardViewModel();
			model.Products = new List<List<Product>>();

			var products = _reader.GetProducts(userId);

			var numRows = products.Count() <= 3 ? 1 :
				products.Count() / 3;

			for (int i = 0; i <= numRows; i++)
			{
				model.Products.Add(products.Skip(i * 3).Take(3).ToList());
			}

			return View(model);
        }

		public IActionResult Product(int productId)
		{
			var product = _reader.GetWithIncludes<Product>().FirstOrDefault(
				p => p.Id.Equals(productId));


			//var author = _reader.GetWithIncludes<Product>().FirstOrDefault(
			//	p => p.Id.Equals(productId));
			//var module = _reader.Get<ListItem>()
			//	.Where(x => x.ProductId == productId);

			var module = from li in _reader.Get<ListItem>()
						 where li.ProductId.Equals(productId)
						 select new ListItem
						 {
							 Id = li.Id,
							 Description = li.Description,
							 Name = li.Name,
							 Product = li.Product,
							 ProductId = li.ProductId,
							 Items = _reader.Get<Item>().Where(i => i.ListItemId.Equals(li.Id)).ToList()
						 };

			//var module = _reader.GetWithIncludes<ListItem>().Where(
			//	x => x.ProductId == productId);



			var model = new ProductViewModel { Product = product, ListItems = module.ToList() };

			return View(model);
		}
		
		public async Task<IActionResult> Item(int itemId)
		{
			var item = _reader.GetWithIncludes<Item>().FirstOrDefault(
				p => p.Id.Equals(itemId));

			var author = _reader.GetWithIncludes<Product>().FirstOrDefault(
				p => p.Id.Equals(item.ListItem.ProductId)).Author;

			var model = new ItemViewModel { Author = author, Item = item };

			//var model = new ProductViewModel { Product = product, ListItems = module.ToList() };

			return View(model);
		}
	}

}