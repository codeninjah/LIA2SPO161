using LIA2Version3.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIA.UI.Models.Membership
{
    public class ProductViewModel
    {
		public Product Product { get; set; }
		public List<ListItem> ListItems { get; set; }
	}
}
