using Autofac;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Infraestructure;
using NMock;
using ServiceWCF;

namespace UnitaryTest
{
    [TestClass]
    public class ArticleTest  
    { 
        private MockFactory _factory = new MockFactory();
        [TestMethod]
        public void TestingArticleGetAll()
        {
            var pruebaTest = 1;
            var article = new Article() { Id = 1, Price = 15, Description = "NARANJITAS" };
            // Arrange
            var repository = _factory.CreateMock<IRepositoryArticle>();
            var unitOfWork = _factory.CreateMock<IUnitOfWork>();
            var articleService = new ServiceArticle(repository.MockObject, unitOfWork.MockObject);
            var articles = new HashSet<Article>() {
                article
            };
            repository.Expects.One.Method(c => c.GetAll()).WillReturn(articles);
            unitOfWork.Expects.One.Method(c => c.Dispose());
            //Act
            var result = articleService.GetAll().ToList();
            //Assert
            Assert.AreEqual(pruebaTest, result.Count());
        }
    }
}
