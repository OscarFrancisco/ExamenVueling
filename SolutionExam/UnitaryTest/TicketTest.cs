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
    public class TicketTest 
    {
        private MockFactory _factory = new MockFactory();
        private const int PRUEBATEST = 1;
        private Ticket _pruebaTestticket;
        [TestCleanup]
        public void Cleanup()
        {
            _factory.VerifyAllExpectationsHaveBeenMet();
            _factory.ClearExpectations();
        }
        [TestInitialize]
        public void Initialize()
        {
            var saleArticle = new SaleArticle()
                                    {
                                        Id = 1,
                                        PriceSale = 10,
                                        Quantity = 5,
                                        ArticleSale = new Article()
                                                        {
                                                            Id = 1
                                                        }
                                    }; 
            _pruebaTestticket = new Ticket()
                                    {
                                        Id = 1,
                                        Articles = new List<SaleArticle>(){saleArticle}
                                    };
        }
        [TestMethod]
        public void TestingTicketGetAll()
        {
            var repository = _factory.CreateMock<IRepositoryTicket>();
            var unitOfWork = _factory.CreateMock<IUnitOfWork>();
            var ticketService = new ServiceTicket(repository.MockObject, unitOfWork.MockObject);
            // Arrange
            var tickets = new HashSet<Ticket>() { _pruebaTestticket };
            repository.Expects.One.Method(c => c.GetAll()).WillReturn(tickets);
            //Act
            var result = new List<Ticket>(ticketService.GetAll());
            //Assert
            Assert.AreEqual(PRUEBATEST, result.Count());
        }
        [TestMethod]
        public void TestingTicketGet()
        {
            var repository = _factory.CreateMock<IRepositoryTicket>();
            var unitOfWork = _factory.CreateMock<IUnitOfWork>();
            var ticketService = new ServiceTicket(repository.MockObject, unitOfWork.MockObject);
            // Arrange
            repository.Expects.One.Method(c => c.Get(1)).WillReturn(_pruebaTestticket);
            //Act
            var result = ticketService.Get(1);
            //Assert
            Assert.AreEqual(PRUEBATEST, result == null ? 0 : 1);
        }
    }
}