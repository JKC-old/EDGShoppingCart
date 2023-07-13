using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EDGShoppingCart.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string? Name { get; set; }
        public string? Description { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }


        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DiscountPrice { get; set; }

        public string ImageFile { get; set; } = string.Empty;
        public BeerType BeerType { get; set; }
        public StateOfOrigin StateOfOrgin { get; set; }

        public int PromoFlag { get; set; }
    }

    public enum BeerType
    {
        Lager = 1,
        PaleAle = 2,
    }

    public enum StateOfOrigin
    {
        NSW=1,
        VIC=2,
        SA=3
    }
}
