using EDGShoppingCart.Data;
using EDGShoppingCart.Models;
using EDGShoppingCart.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EDGShoppingCart.Repositories
{
    public class DiscountRepository : IDiscountRepositry
    {
        protected readonly EDGShoppingCartContext _dbContext;
        public DiscountRepository(EDGShoppingCartContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Discount> GetDiscountByUserName(string userName)
        {
            var disc = _dbContext.Discount.FirstOrDefault(c => c.UserName == userName);

            if (disc != null) 
            { 
                return disc;
            }
            // if it is first attempt create new
            var newDiscount = new Discount
            {
                UserName = userName
            };

            _dbContext.Discount.Add(newDiscount);
            await _dbContext.SaveChangesAsync();
            return newDiscount;
        }

        public async Task AddPromotionFlag(string userName, int promotionFlag)
        {
            var disc = await GetDiscountByUserName(userName);
            if (disc != null)
            {
                disc.PromotionFlag = promotionFlag;
                _dbContext.Entry(disc).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
        }

        public int GetFlagValue(string userName)
        {
            var disc = _dbContext.Discount.FirstOrDefault(c => c.UserName == userName);
            if (disc != null)
            {
                return disc.PromotionFlag;
            }
            return 0;
        }
    }
}
