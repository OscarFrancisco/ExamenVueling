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
        private Mock<IRepositoryTicket> _repository;
        private Mock<IUnitOfWork> _unitOfWork;
        private IServiceTicket _ticketService;
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
            _repository = _factory.CreateMock<IRepositoryTicket>();
            _unitOfWork = _factory.CreateMock<IUnitOfWork>();
            _ticketService = new ServiceTicket(_repository.MockObject, _unitOfWork.MockObject);
        }
        [TestMethod]
        public void TestingTicketGetAll()
        {
            // Arrange
            var tickets = new HashSet<Ticket>() { _pruebaTestticket };
            _repository.Expects.One.Method(c => c.GetAll()).WillReturn(tickets);
            //Act
            var result = new List<Ticket>(_ticketService.GetAll());
            //Assert
            Assert.AreEqual(PRUEBATEST, result.Count());
        }
        [TestMethod]
        public void TestingTicketGet()
        {
            // Arrange
            _repository.Expects.One.MethodWith(c => c.Get(1)).WillReturn(_pruebaTestticket);
            //Act
            var result = _ticketService.Get("1"); 
            //Assert
            Assert.AreEqual(PRUEBATEST, result == null ? 0 : 1);
        }
        [TestMethod]
        public void TestingTicketAdd()
        {
            // Arrange
            _repository.Expects.Any.MethodWith(c => c.Add(_pruebaTestticket)).WillReturn(_pruebaTestticket);
            _unitOfWork.Expects.Any.MethodWith(c => c.SaveChanges()).WillReturn(1);
            //Act
            var result = _ticketService.Add(_pruebaTestticket);
            //Assert
            Assert.AreEqual(PRUEBATEST, result.Articles.Count);
        }
        [TestMethod]
        public void TestingTicketUpdate()
        {
            // Arrange
            _repository.Expects.Any.MethodWith(c => c.Update(_pruebaTestticket)).Will();
            _unitOfWork.Expects.Any.MethodWith(c => c.SaveChanges()).WillReturn(1);
            _repository.Expects.One.MethodWith(c => c.Get(1)).WillReturn(_pruebaTestticket);
            //Act
            _ticketService.Update(_pruebaTestticket);
            var result = _ticketService.Get("1");
            //Assert
            Assert.AreEqual(PRUEBATEST, result.Articles.Count);
        }
    }
}