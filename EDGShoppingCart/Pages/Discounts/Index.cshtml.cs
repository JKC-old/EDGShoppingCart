using EDGShoppingCart.Models;
using EDGShoppingCart.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDGShoppingCart.Pages.Discounts
{
    public class IndexModel : PageModel
    {

        private readonly EDGShoppingCart.Data.EDGShoppingCartContext _context;
        private readonly IDiscountRepositry _discountRepository;
        private readonly ICartRepository _cartRepository;

        public IndexModel(EDGShoppingCart.Data.EDGShoppingCartContext context, IDiscountRepositry discountRepository, ICartRepository cartRepository)
        {
            _context = context;
            _discountRepository = discountRepository ?? throw new ArgumentNullException(nameof(discountRepository));
            _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
        }
        public IList<Promotion> Promotions { get; set; } = default!;

        [BindProperty]
        public List<string> SelectedOptions { get; set; } = new List<string>();
        public Models.Discount Discount { get; set; } = new Models.Discount();
        public Models.Cart Cart { get; set; } = null!;
        public int PromoFlag
        {
            get
            {
                return _discountRepository.GetFlagValue("EDG");
            }
        }
        public async Task<IActionResult> OnGetAsync()
        {
            Discount = await _discountRepository.GetDiscountByUserName("EDG");
            Cart = await _cartRepository.GetCartByUserName("EDG");
            Promotions = _context.Promotions.ToList();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var disc = _discountRepository.GetDiscountByUserName("EDG");
            if (disc != null)
            {
                if (SelectedOptions != null && SelectedOptions.Count > 0)
                {
                    int flag = 0;
                    foreach (var item in SelectedOptions)
                    {
                        if (int.TryParse(item, out int selectedFlagValue))
                        {
                            flag += selectedFlagValue;
                        }
                    }
                    if (flag > -1)
                    {
                        await _discountRepository.AddPromotionFlag("EDG", flag);
                    }
                }
            }
            //Just reset the cart values every time that the discount is submitted
            var currentCart = _cartRepository.GetCartByUserName("EDG");
            if (currentCart != null)
            {
                await _cartRepository.ResetDiscounts(currentCart.Id);
            }

            return RedirectToPage();
        }
    }
}
