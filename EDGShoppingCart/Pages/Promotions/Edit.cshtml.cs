using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EDGShoppingCart.Data;
using EDGShoppingCart.Models;

namespace EDGShoppingCart.Pages.Promotions
{
    public class EditModel : PageModel
    {
        private readonly EDGShoppingCart.Data.EDGShoppingCartContext _context;

        public EditModel(EDGShoppingCart.Data.EDGShoppingCartContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Promotion Promotion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Promotions == null)
            {
                return NotFound();
            }

            var promotions =  await _context.Promotions.FirstOrDefaultAsync(m => m.Id == id);
            if (promotions == null)
            {
                return NotFound();
            }
            Promotion = promotions;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Promotion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromotionsExists(Promotion.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PromotionsExists(int id)
        {
          return (_context.Promotions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
