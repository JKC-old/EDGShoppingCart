using EDGShoppingCart.Data;
using Microsoft.EntityFrameworkCore;

namespace EDGShoppingCart
{
    public class Global
    {
        public enum PromotionFlags
        {
            None = 0,
            VB = 2,
            Coopers = 4,
            SpendFifty = 8
        }

    }
}
