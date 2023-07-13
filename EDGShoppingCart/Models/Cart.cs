namespace EDGShoppingCart.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public decimal BuyGetFreeDiscountTotal { get ; set; }          // This should be a negative number for the Coopers promo

        public decimal SpendOverFiftyDiscountTotal { get; set; }

        public decimal TotalPrice
        {
            get 
            {
                decimal totalprice = 0;
                foreach (var item in Items)
                {
                    totalprice += item.Price * item.Quantity;
                }
                return totalprice + BuyGetFreeDiscountTotal + SpendOverFiftyDiscountTotal;
            }
        }
    }
}
