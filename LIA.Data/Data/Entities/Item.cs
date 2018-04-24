﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LIA2Version3.Data.Entities
{
    public class Item
    {
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public int ItemTypeId { get; set; }
		public ItemType ItemType { get; set; }
		public string Link { get; set; }

		[MaxLength(50)]
		public string Description { get; set; }

		//public ICollection<ItemType> ItemTypes { get; set; }
	}
}
