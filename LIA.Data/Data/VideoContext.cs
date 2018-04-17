using LIA2Version3.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIA.Data.Data
{
    public class VideoContext: IdentityDbContext<User>, IVideoContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<ListItem> ListItems { get; set; }
        public DbSet<UserProduct> UserProducts { get; set; }
        public DbSet<User> Users { get; set; }

        public VideoContext(DbContextOptions<VideoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Composite key
            builder.Entity<UserProduct>().HasKey(uc => new { uc.UserId, uc.ProductId });

            // Restrict cascading deletes
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
