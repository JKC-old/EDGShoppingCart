using EDGShoppingCart.Repositories;
using EDGShoppingCart.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace EDGShoppingCart.Pages.ProductDetail
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
        public Models.Product? Product { get; set; }

        public int PromoFlag 
        {
            get
            {
                return  _discountRepository.GetFlagValue("EDG");
            }
        }

        [BindProperty]
        public int Quantity { get; set; }

        public Models.Cart Cart { get; set; } = new Models.Cart();

        public async Task<IActionResult> OnGetAsync(int? productId)
        {
            if (productId == null)
            {
                return NotFound();
            }

            Product = await _context.Product.FirstOrDefaultAsync(p => p.Id == productId);

            CheckPromo();

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        {
            await _cartRepository.AddItem("EDG", productId, Quantity);
            return RedirectToPage("/Cart/Index");
        }

        private void CheckPromo()
        {

            if (Product != null)
            {
                if ((PromoFlag & (int)Global.PromotionFlags.VB) == (int)Global.PromotionFlags.VB) 
                {
                    if ((Product.PromoFlag & (int)Global.PromotionFlags.VB) == (int)Global.PromotionFlags.VB)
                    {
                        Product.DiscountPrice = Product.Price - 2;
                    }
                }
            }
        }
    }
}
