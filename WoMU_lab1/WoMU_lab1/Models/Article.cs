using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace WoMU_lab1.Models
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }
        public string ArticleName { get; set; }
        public string ArticleDescription { get; set; }
        public decimal ArticlePrice { get; set; }
        public int ArticleInStock { get; set; }
    }
    public class ArticleDBContext : DbContext
    {
        public DbSet<Article> Article { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}