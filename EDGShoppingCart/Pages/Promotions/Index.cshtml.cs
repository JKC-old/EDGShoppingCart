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
    public class IndexModel : PageModel
    {
        private readonly EDGShoppingCart.Data.EDGShoppingCartContext _context;

        public IndexModel(EDGShoppingCart.Data.EDGShoppingCartContext context)
        {
            _context = context;
        }

        public IList<EDGShoppingCart.Models.Promotion> Promotions { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Promotions != null)
            {
                Promotions = await _context.Promotions.ToListAsync();
            }
        }
    }
}
