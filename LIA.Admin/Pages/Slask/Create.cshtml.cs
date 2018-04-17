using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LIA.Data.Data;
using LIA2Version3.Data.Entities;

namespace LIA.Admin.Pages.Slask
{
    public class CreateModel : PageModel
    {
        private readonly LIA.Data.Data.VideoContext _context;

        public CreateModel(LIA.Data.Data.VideoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ItemType ItemType { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ItemTypes.Add(ItemType); //LÄGG TILL I SERVICEN
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}