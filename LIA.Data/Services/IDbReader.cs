using LIA2Version3.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIA.Data.Services
{
    public interface IDbReader
    {
        IQueryable<TEntity> Get<TEntity>() where TEntity : class;
		Task<TEntity> Get<TEntity>(int id) where TEntity : class;
		IEnumerable<TEntity> GetWithIncludes<TEntity>() where TEntity : class;
		SelectList GetSelectList<TEntity>(string valueString, string textField) where TEntity : class;
		TEntity Get<TEntity>(string userId, int id) where TEntity : class;
		User Get(string userId);
	}
}
