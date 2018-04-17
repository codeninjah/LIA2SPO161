using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LIA.Data.Data;
using LIA2Version3.Data.Entities;

namespace LIA.Admin.Pages.Slask
{
    public class IndexModel : PageModel
    {
        private readonly LIA.Data.Data.VideoContext _context;

        public IndexModel(LIA.Data.Data.VideoContext context)
        {
            _context = context;
        }

        public IList<ItemType> ItemType { get;set; }

        public async Task OnGetAsync()
        {
            ItemType = await _context.ItemTypes.ToListAsync();
        }
    }
}
