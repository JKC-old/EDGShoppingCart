using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EDGShoppingCart.Models;

namespace EDGShoppingCart.Data
{
    public class EDGShoppingCartContext : DbContext
    {
        public EDGShoppingCartContext (DbContextOptions<EDGShoppingCartContext> options)
            : base(options){ }

        public DbSet<EDGShoppingCart.Models.Product> Product { get; set; } = default!;
        public DbSet<EDGShoppingCart.Models.Cart> Cart { get; set; }
        public DbSet<EDGShoppingCart.Models.CartItem> CartItem { get; set; }
        public DbSet<EDGShoppingCart.Models.Promotion> Promotions { get; set; } = default!;
        public DbSet<EDGShoppingCart.Models.Discount> Discount { get; set; }

    }
}
