using EDGShoppingCart.Models;
using System.Threading.Tasks;


namespace EDGShoppingCart.Repositories.Interfaces
{
    public interface IDiscountRepositry
    {
        Task<Discount> GetDiscountByUserName(string userName);
        Task AddPromotionFlag(string userName, int promotionFlag);

        int GetFlagValue(string userName);

    }
}
