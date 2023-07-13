using EDGShoppingCart.Models;
using System.Threading.Tasks;

namespace EDGShoppingCart.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart> GetCartByUserName(string userName);
        Task AddItem(string userName, int productId, int quantity = 1);
        Task RemoveItem(int cartId, int cartItemId);
        Task ClearCart(string userName);

        Task UpdateQuantityCartItem(int cartId, int cartItemId, int quantity);

        Task ResetDiscounts(int cartId);
    }
}
