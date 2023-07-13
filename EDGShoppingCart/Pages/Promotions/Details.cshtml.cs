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
    public class DetailsModel : PageModel
    {
        private readonly EDGShoppingCart.Data.EDGShoppingCartContext _context;

        public DetailsModel(EDGShoppingCart.Data.EDGShoppingCartContext context)
        {
            _context = context;
        }

      public Promotion Promotion { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Promotions == null)
            {
                return NotFound();
            }

            var promotion = await _context.Promotions.FirstOrDefaultAsync(m => m.Id == id);
            if (promotion == null)
            {
                return NotFound();
            }
            else 
            {
                Promotion = promotion;
            }
            return Page();
        }
    }
}
