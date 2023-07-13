using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EDGShoppingCart.Models
{
    public class Discount
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        
        public int PromotionFlag { get; set; }

        public decimal GetPrice
        {
            get
            {
                //decimal totalprice = 0;
                //foreach (var item in Items)
                //{
                //    totalprice += item.Price * item.Quantity;
                //}
                //return totalprice;
                return 0;
            }
        }
    }
}
