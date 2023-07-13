using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EDGShoppingCart.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Definition { get; set; }

        public int BinaryFlag { get; set; }     // 1 = VB | 2 = Coopers | 3 = Spend 50

    }
}
