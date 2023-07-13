using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EDGShoppingCart.Data;
using EDGShoppingCart.Models;

namespace EDGShoppingCart.Pages.Promotions
{
    public class DeleteModel : PageModel
    {
        private readonly EDGShoppingCart.Data.EDGShoppingCartContext _context;

        public DeleteModel(EDGShoppingCart.Data.EDGShoppingCartContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Promotion Promotions { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Promotions == null)
            {
                return NotFound();
            }

            var promotions = await _context.Promotions.FirstOrDefaultAsync(m => m.Id == id);

            if (promotions == null)
            {
                return NotFound();
            }
            else 
            {
                Promotions = promotions;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Promotions == null)
            {
                return NotFound();
            }
            var promotions = await _context.Promotions.FindAsync(id);

            if (promotions != null)
            {
                Promotions = promotions;
                _context.Promotions.Remove(Promotions);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
