using LIA2Version3.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIA.Data.Data
{
    public interface IVideoContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<ItemType> ItemTypes { get; set; }
        DbSet<ListItem> ListItems { get; set; }
        DbSet<UserProduct> UserProducts { get; set; }
		DbSet<User> Users { get; set; }
    }
}
