using Microsoft.EntityFrameworkCore;
using EDGShoppingCart.Data;

namespace EDGShoppingCart.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EDGShoppingCartContext(serviceProvider.GetRequiredService<DbContextOptions<EDGShoppingCartContext>>()))
            {
                if (context == null || context.Product == null || context.Promotions == null)
                {
                    throw new ArgumentNullException("Null EdgShoppingCartContext");
                }

                if (!context.Promotions.Any())
                {
                    context.Promotions.AddRange(
                        new Promotion
                        {
                            Name = "No Promotions",
                            Definition = "Full Price",
                            BinaryFlag = (int)(Global.PromotionFlags.None),
                            Description = "All items will be full price"
                        },
                        new Promotion
                        {
                            Name = "Current month special on VB",
                            Definition = "$2.00 off",
                            BinaryFlag = (int)(Global.PromotionFlags.VB),
                            Description = "VB products gets $2 off price"
                        },
                        new Promotion
                        {
                            Name = "BOGOF on Coopers",
                            Definition = "Buy one and get on free",
                            BinaryFlag= (int)(Global.PromotionFlags.Coopers),
                            Description = "Coopers products buy one get one free"
                        },
                        new Promotion
                        {
                            Name = "Spend and Save",
                            Definition = "Spend $50 and $5 off the total",
                            BinaryFlag= (int)(Global.PromotionFlags.SpendFifty),
                            Description = "Need to spend $50 before to get $5 off"
                        }
                    );
                }

                if (!context.Product.Any())
                {
                    context.Product.AddRange(
                        new Product
                        {
                            Name = "Victoria Bitter",
                            Code = "VB",
                            Description = "The 'Big Cold Beer', Victoria Bitter has long been Australia's favourite beer. The great taste brewed to deliver full-bodied flavour when ice cold, will quench any hard earned thirst.",
                            ImageFile = "Product-1.png",
                            BeerType = BeerType.Lager,
                            StateOfOrgin=StateOfOrigin.VIC,
                            PromoFlag = (int)(Global.PromotionFlags.VB | Global.PromotionFlags.SpendFifty),
                            Price = 21.49M,
                            DiscountPrice = 21.49M
                        },
                        new Product
                        {
                            Name = "Crown Lager",
                            Code = "CL",
                            Description = "Crown Lager has a bright golden appearance with a solid creamy head. The fruity aroma transforms to a malty refreshing taste with a smooth, full bodied finish. The slightly lingering bitterness gives a balanced, rounded experience which will make you want more.",
                            ImageFile = "Product-2.png",
                            BeerType = BeerType.Lager,
                            StateOfOrgin = StateOfOrigin.VIC,
                            PromoFlag = (int)(Global.PromotionFlags.SpendFifty),
                            Price = 22.99M,
                            DiscountPrice = 22.99M
                        },
                        new Product
                        {
                            Name = "Coopers",
                            Code = "CO",
                            Description = "Coopers Pale Ale The Original Pale Ale. Beware of pale imitations. Guaranteed to turn heads, this is the beer that inspired a new generation of ale drinkers. With its fruity and floral characters, balanced with a crisp bitterness, Coopers Pale Ale has a compelling flavour which is perfect for every occasion.",
                            ImageFile = "Product-3.png",
                            BeerType = BeerType.PaleAle,
                            StateOfOrgin = StateOfOrigin.SA,
                            PromoFlag = (int)(Global.PromotionFlags.Coopers | Global.PromotionFlags.SpendFifty),
                            Price = 20.49M,
                            DiscountPrice = 20.49M
                        },
                        new Product
                        {
                            Name = "Tooheys Extra Dry",
                            Code = "TED",
                            Description = "Tooheys Extra Dry is well known for its clean, refreshing taste. Its crisp, dry finish is achieved by an extended fermentation, ensuring minimal residual fermentable sugars. Wonderful fruity, malty notes accompany a mellow middle palate, leaving a clean aftertaste.",
                            ImageFile = "Product-4.png",
                            BeerType = BeerType.Lager,
                            StateOfOrgin = StateOfOrigin.NSW,
                            PromoFlag = (int)(Global.PromotionFlags.SpendFifty),
                            Price = 19.99M,
                            DiscountPrice = 19.99M
                        }
                    );
                }

                context.SaveChanges();
            }
        }
    }
}
