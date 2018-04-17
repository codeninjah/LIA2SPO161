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
    public class DeleteModel : PageModel
    {
        private readonly LIA.Data.Data.VideoContext _context;

        public DeleteModel(LIA.Data.Data.VideoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ItemType ItemType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ItemType = await _context.ItemTypes.SingleOrDefaultAsync(m => m.ItemTypeId == id);

            if (ItemType == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ItemType = await _context.ItemTypes.FindAsync(id);

            if (ItemType != null)
            {
                _context.ItemTypes.Remove(ItemType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
