namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WoMU_lab1.Models;
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
            ArticleName = "LSD",
            ArticleDescription = "Fresh from the sidewalk",
            ArticlePrice = 0.99M,
            ArticleInStock = 30000
        },

         new Article
         {
             ArticleName = "Snabel",
             ArticleDescription = "What's up that trunk?",
             ArticlePrice = 18.99M,
             ArticleInStock = 3
         },

         new Article
         {
             ArticleName = "Random stöldgods",
             ArticleDescription = "Du kan få en bil...",
             ArticlePrice = 85.50M,
             ArticleInStock = 10000
         },

       new Article
       {
           ArticleName = "Shiv",
           ArticleDescription = "It's made of cheese and self-loathing",
           ArticlePrice = 0.95M,
           ArticleInStock = 1
       }
   );

        }
    }
}
