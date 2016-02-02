using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WoMU_lab1.Models
{
    public class ShoppingCartVM
    {
        [Key]
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}
