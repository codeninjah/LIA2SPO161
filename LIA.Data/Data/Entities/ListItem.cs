using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LIA2Version3.Data.Entities
{
    public class ListItem
    {
		[Key]
		public int ListItemId { get; set; }
		public string Name { get; set; }
		//public int ItemsID { get; set; }
		public string Description { get; set; }
		//public int ProductsID { get; set; }

		public ICollection<Product> Products { get; set; }
		public ICollection<Item> Items { get; set; }
	}
}
