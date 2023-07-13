using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EDGShoppingCart.Data;
using EDGShoppingCart.Models;
using EDGShoppingCart.Repositories.Interfaces;
using EDGShoppingCart.Repositories;

namespace EDGShoppingCart.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly EDGShoppingCart.Data.EDGShoppingCartContext _context;
        private readonly ICartRepository _cartRepository;
        private readonly IDiscountRepositry _discountRepository;

        public IndexModel(EDGShoppingCart.Data.EDGShoppingCartContext context, ICartRepository cartRepository, IDiscountRepositry discountRepository)
        {
            _context = context;
            _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
            _discountRepository = discountRepository ?? throw new ArgumentNullException(nameof(discountRepository));
        }

        public IEnumerable<Models.Product> Products { get; set; } = new List<Models.Product>();
        public int PromoFlag
        {
            get
            {
                return _discountRepository.GetFlagValue("EDG");
            }
        }
        public async Task OnGetAsync()
        {
            if (_context.Product != null)
            {
                Products = await _context.Product.ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        {
            await _cartRepository.AddItem("EDG", productId);
            return RedirectToPage("/Cart/Index");
        }

    }
}
