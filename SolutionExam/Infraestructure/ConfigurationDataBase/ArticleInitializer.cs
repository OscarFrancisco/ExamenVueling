using Domain;
using System;
using System.Data.Entity;

namespace Infraestructure
{
    public class ArticleInitializer : DropCreateDatabaseAlways<AppShopContext>
    {
        public ArticleInitializer():base() { }
        protected override void Seed(AppShopContext context)
        {
            context.Articles.Add(new Article() { Description = "Peras", Price = 3.40M });
            context.Articles.Add(new Article() { Description = "Manzanas", Price = 1.30M });
            context.Articles.Add(new Article() { Description = "Naranjas", Price = 1.32M });
            context.SaveChanges();
        }
    }
}
