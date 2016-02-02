namespace WoMU_lab1.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WoMU_lab1.Models.ArticleDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WoMU_lab1.Models.ArticleDBContext";
        }

        protected override void Seed(WoMU_lab1.Models.ArticleDBContext context)
        {
            context.Article.AddOrUpdate(i => i.ArticleName,
        new Article
        {
            ArticleName = "Nope1",
            ArticleDescription = "Wut?",
            ArticlePrice = 8.99M,
            ArticleInStock = 3
    },

         new Article
         {
             ArticleName = "Nope2",
             ArticleDescription = "Wut?",
             ArticlePrice = 8.99M,
             ArticleInStock = 3
         },

         new Article
         {
             ArticleName = "Nope3",
             ArticleDescription = "Wut?",
             ArticlePrice = 8.99M,
             ArticleInStock = 3
         },

       new Article
       {
           ArticleName = "Nope4",
           ArticleDescription = "Wut?",
           ArticlePrice = 8.99M,
           ArticleInStock = 3
       }
   );

        }
    }
}
