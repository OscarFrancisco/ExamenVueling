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
        private const int PRUEBATEST = 1;
        private Mock<IRepositoryArticle> _repository;
        private Mock<IUnitOfWork> _unitOfWork;
        private IServiceArticle _articleService;
        [TestCleanup]
        public void Cleanup()
        {
            _factory.ClearExpectations();
            _repository.ClearExpectations();
            _unitOfWork.ClearExpectations();
        }
        [TestInitialize]
        public void Initialize()
        {
            _repository = _factory.CreateMock<IRepositoryArticle>();
            _unitOfWork = _factory.CreateMock<IUnitOfWork>();
            _articleService = new ServiceArticle(_repository.MockObject, _unitOfWork.MockObject);
        }
        [TestMethod]
        public void TestingArticleGetAll()
        {
            var article = new Article() { Id = 1, Price = 15, Description = "NARANJITAS" };
            // Arrange
            var articles = new HashSet<Article>() {
                article
            };
            _repository.Expects.One.Method(c => c.GetAll()).WillReturn(articles);
            _unitOfWork.Expects.One.Method(c => c.Dispose());
            //Act
            var result = new List<Article>(_articleService.GetAll());
            //Assert
            Assert.AreEqual(PRUEBATEST, result.Count());
            Assert.AreEqual(article, result[0]);
        }
    }
}
