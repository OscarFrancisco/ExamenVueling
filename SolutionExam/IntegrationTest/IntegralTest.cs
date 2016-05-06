using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceWCF;
using System.Collections.Generic;
using Infraestructure;

namespace IntegrationTest
{
    [TestClass]
    public class IntegralTest
    {
        private ServiceBase _serviceBase;
        private readonly int MOVIECOUNT = 1;
        private IEnumerable<dynamic> integral;

        [TestMethod]
        public void TestMethod1()
        {
            using (var ctx = new AppShopContext())
            {
                //ctx.Tickets.
                /*ctx.Products.Add(new Product() { Name = "Naranjas" });
                ctx.SaveChanges();*/
            }
            /*var result = _productController.Index() as ViewResult;
            var movies = result.Model as IEnumerable<Product>;
            Assert.AreEqual(MOVIECOUNT, movies.ToList().Count);*/
        }
        [TestInitialize]
        public void SetUp()
        {
            using (var ctx = new AppShopContext())
            {
                if (ctx.Database.Exists())
                    ctx.Database.Delete();
                ctx.Database.Create();
            } 
        } 
    }
}
