using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoMU_lab1.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ArticleId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Article Article { get; set; }
        public virtual Order Order { get; set; }
        
    }
}
