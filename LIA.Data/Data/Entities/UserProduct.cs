using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIA2Version3.Data.Entities
{
    public class UserProduct
    {
		public int ProductId { get; set; }
		public string UserId { get; set; }
		public User User { get; set; }
		public Product Product { get; set; }

		//public ICollection<User> Users { get; set; }
		//public ICollection<Product> Products { get; set; }
	}
}
