using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LIA2Version3.Data.Entities
{
    public class ItemType
    {
		[Key]
		public int ItemTypeId { get; set; }
		public string Name { get; set; }
	}
}
