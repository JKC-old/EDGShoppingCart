using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EDGShoppingCart.Models;
using EDGShoppingCart.Repositories.Interfaces;
using EDGShoppingCart.Repositories;

namespace EDGShoppingCart.Pages.Cart
{
    public class IndexModel : PageModel
    {
        private readonly ICartRepository _cartRepository;
        private readonly IDiscountRepositry _discountRepository;

        public IndexModel(ICartRepository cartRepository, IDiscountRepositry discountRepository)
        {
            _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
            _discountRepository = discountRepository ?? throw new ArgumentNullException(nameof(discountRepository));
        }

        public Models.Cart Cart { get; set; } = new Models.Cart();
        public int PromoFlag
        {
            get
            {
                return _discountRepository.GetFlagValue("EDG");
            }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Cart = await _cartRepository.GetCartByUserName("EDG");
            CheckPromo();
            return Page();
        }

        public async Task<IActionResult> OnPostRemoveFromCartAsync(int cartId, int cartItemId)
        {
            await _cartRepository.RemoveItem(cartId, cartItemId);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostUpdateCartAsync(Dictionary<int, int> cartItemQuantities)
        {
            Cart = await _cartRepository.GetCartByUserName("EDG");

            foreach (var cartItem in Cart.Items)
            {
                if (cartItemQuantities.ContainsKey(cartItem.Id))
                {
                    int updatedQuantity = cartItemQuantities[cartItem.Id];
                    cartItem.Quantity = updatedQuantity;

                    await _cartRepository.UpdateQuantityCartItem(Cart.Id, cartItem.Id, updatedQuantity);
                }
            }

            return RedirectToPage();
        }

        private void CheckPromo()
        {
            if (Cart != null)
            {
                
                int coopersFreeTotal = 0;
                decimal singleCoopers = 0;
                foreach (var cartItem in Cart.Items)
                {
                    if ((PromoFlag & (int)Global.PromotionFlags.VB) == (int)Global.PromotionFlags.VB)
                    {
                        if ((cartItem.Product.PromoFlag & (int)Global.PromotionFlags.VB) == (int)Global.PromotionFlags.VB)
                        {
                            cartItem.Price = cartItem.Product.Price - 2;
                        }
                    }

                    if ((PromoFlag & (int)Global.PromotionFlags.Coopers) == (int)Global.PromotionFlags.Coopers)
                    {
                        if ((cartItem.Product.PromoFlag & (int)Global.PromotionFlags.Coopers) == (int)Global.PromotionFlags.Coopers)
                        {
                            coopersFreeTotal += cartItem.Quantity;
                            singleCoopers = cartItem.Product.Price;
                        }
                    }
                }

                if (coopersFreeTotal > 0)
                {
                    Cart.BuyGetFreeDiscountTotal = (-singleCoopers * (coopersFreeTotal / 2));
                }

                if ((PromoFlag & (int)Global.PromotionFlags.SpendFifty) == (int)Global.PromotionFlags.SpendFifty)
                {
                    if (Cart.TotalPrice > 49)
                    {
                        Cart.SpendOverFiftyDiscountTotal = -5;
                    }
                }
            }
        }
    }
}
