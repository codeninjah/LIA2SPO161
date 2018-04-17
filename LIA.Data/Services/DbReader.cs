using LIA.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using LIA2Version3.Data.Entities;

namespace LIA.Data.Services
{
    public class DbReader : IDbReader
    {
        private VideoContext _db;
        public DbReader(VideoContext db)
        {
            _db = db;
        }

        public IQueryable<TEntity> Get<TEntity>() where TEntity : class
        {
            return _db.Set<TEntity>();
        }

		public async Task<TEntity> Get<TEntity>(int id) where TEntity : class
		{
			return await _db.FindAsync<TEntity>(id);
		}

		public TEntity Get<TEntity>(string userId, int id) where TEntity : class
		{
			return _db.Set<TEntity>().Find(new object[] { userId, id });
		}

		public User Get(string userId)
		{
			return _db.Set<User>().Find(new object[] { userId });
		}

		public SelectList GetSelectList<TEntity>(string valueField, string textField) where TEntity : class
		{
			var items = Get<TEntity>();
			return new SelectList(items, valueField, textField);
		}

		public IEnumerable<TEntity> GetWithIncludes<TEntity>() where TEntity : class
		{
			//Tar fram namnen
			var entityNames = GetEntityNames<TEntity>();

			//Gör (i detta fall UserProduct) tillgänglig
			var dbset = _db.Set<TEntity>();

			//Slår ihop namnen på entiteterna
			var entities = entityNames.collections.Union(entityNames.references);

			//Loppar igenom entitetsnamnet och laddar tillgängliga entiteter
			// dvs. entiteter som har namn
			foreach (var entity in entities)
				_db.Set<TEntity>().Include(entity).Load();

			return dbset;
		}

		private (IEnumerable<string> collections, IEnumerable<string> references) GetEntityNames<TEntity>() where TEntity : class
		{
			//Hämtar ut alla properties av typen DbSet i VideoContext
			var dbsets = typeof(VideoContext)
				.GetProperties(BindingFlags.Public | BindingFlags.Instance)
				.Where(z => z.PropertyType.Name.Contains("DbSet"))
				.Select(z => z.Name);

			// Get the names of all the properties (tables) in the generic
			// type T that is represented by a DbSet
			var properties = typeof(TEntity)
				.GetProperties(BindingFlags.Public | BindingFlags.Instance);

			var collections = properties
				.Where(l => dbsets.Contains(l.Name))
				.Select(s => s.Name);

			var classes = properties
				.Where(c => dbsets.Contains(c.Name + "s"))
				.Select(s => s.Name);

			return (collections: collections, references: classes);
		}

	}
}
