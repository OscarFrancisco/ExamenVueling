using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceWCF;
using System.Collections.Generic;
using Infraestructure;
using Domain;

namespace IntegrationTest
{
    [TestClass]
    public class IntegralTest
    {
        private ServiceArticle _serviceArticle;
        private readonly int ARTICLECOUNT = 1;
        private IEnumerable<Article> _articles;
        [TestInitialize]
        public void SetUp()
        {
            using (var context = new AppShopContext())
            {
                _serviceArticle = new ServiceArticle(new RepositoryArticle(context), context);
                if (context.Database.Exists())
                {
                    context.Database.Delete();
                }
                context.Database.Create();
            }
        } 
        [TestMethod]
        public void TestMethodIntegrationArticle()
        {
            using (var context = new AppShopContext())
            {
                context.Articles.Add(new Article() { Id = 1, Description = "Naranjitas", Price = 15 });
                context.SaveChanges();
            }
            var result = new List<Article>(_serviceArticle.GetAll());
            Assert.AreEqual(ARTICLECOUNT, result.Count);
        }
    }
}