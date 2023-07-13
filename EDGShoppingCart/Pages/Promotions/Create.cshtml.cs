using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EDGShoppingCart.Data;
using EDGShoppingCart.Models;

namespace EDGShoppingCart.Pages.Promotions
{
    public class CreateModel : PageModel
    {
        private readonly EDGShoppingCart.Data.EDGShoppingCartContext _context;

        public CreateModel(EDGShoppingCart.Data.EDGShoppingCartContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Promotion Promotions { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Promotions == null || Promotions == null)
            {
                return Page();
            }

            _context.Promotions.Add(Promotions);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
