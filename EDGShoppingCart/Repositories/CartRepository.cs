using EDGShoppingCart.Models;
using EDGShoppingCart.Data;
using EDGShoppingCart.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace EDGShoppingCart.Repositories
{
    public class CartRepository : ICartRepository
    {
        protected readonly EDGShoppingCartContext _dbContext;
        public CartRepository(EDGShoppingCartContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<Cart> GetCartByUserName(string userName)
        {
            var cart = _dbContext.Cart
                        .Include(c => c.Items)
                            .ThenInclude(i => i.Product)
                        .FirstOrDefault(c => c.UserName == userName);

            if (cart != null)
                return cart;

            // if it is first attempt create new
            var newCart = new Cart
            {
                UserName = userName
            };

            _dbContext.Cart.Add(newCart);
            await _dbContext.SaveChangesAsync();
            return newCart;
        }
        public async Task AddItem(string userName, int productId, int quantity = 1)
        {
            var cart = await GetCartByUserName(userName);
            var prod = _dbContext.Product.FirstOrDefault(p => p.Id == productId);

            if (cart != null & prod != null)
            {
                cart.Items.Add(
                    new CartItem
                    {
                        ProductId = productId,
                        Price = prod.Price,
                        Quantity = quantity
                        
                    }
                );

                _dbContext.Entry(cart).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task RemoveItem(int cartId, int cartItemId)
        {
            var cart = _dbContext.Cart.Include(c => c.Items).FirstOrDefault(c => c.Id == cartId);

            if (cart != null)
            {
                var removeItem = cart.Items.FirstOrDefault(x => x.Id == cartItemId);

                if (removeItem != null)
                {
                    cart.Items.Remove(removeItem);

                    _dbContext.Entry(cart).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
        public async Task ClearCart(string userName)
        {
            var cart = await GetCartByUserName(userName);

            cart.Items.Clear();

            _dbContext.Entry(cart).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task ResetDiscounts(int cartId)
        {
            var cart = _dbContext.Cart.Include(c => c.Items).FirstOrDefault(c => c.Id == cartId);
            if (cart != null)
            {
                cart.BuyGetFreeDiscountTotal = 0;
                cart.SpendOverFiftyDiscountTotal = 0;
                _dbContext.Entry(cart).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateQuantityCartItem(int cartId, int cartItemId, int quantity)
        {
            var cart = _dbContext.Cart.Include(c => c.Items).FirstOrDefault(c => c.Id == cartId);

            if (cart != null)
            {
                var cartItem = cart.Items.FirstOrDefault(c => c.Id == cartItemId);
                if(cartItem != null)
                {
                    cartItem.Quantity = quantity;
                    _dbContext.Entry(cart).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
