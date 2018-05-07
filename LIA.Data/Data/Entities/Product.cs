using LIA.Data.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LIA2Version3.Data.Entities
{
    public class Product
    {
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
		public int Price { get; set; }
		public int AuthorId { get; set; }
		public DateTime Date { get; set; }
		public string Description { get; set; }
		public Author Author { get; set; }
	}
}
