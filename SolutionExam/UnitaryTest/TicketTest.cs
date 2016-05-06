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
        [TestMethod]
        public void TestingTicketGetAll()
        {
            var pruebaTest = 1;
            var pruebaTestticket = new Ticket(){
                                        Id = 1,
                                        Articles = new List<SaleArticle>()
                                        {
                                            new SaleArticle()
                                                    {
                                                    Id = 1,
                                                    PriceSale = 10,
                                                    Quantity = 5,
                                                    ArticleSale = new Article()
                                                    {
                                                        Id = 1
                                                    }
                                                }
                                        }
                                    };
           // Arrange
            var repository = _factory.CreateMock<IRepositoryTicket>();
            var unitOfWork = _factory.CreateMock<IUnitOfWork>();
            var ticketService = new ServiceTicket(repository.MockObject, unitOfWork.MockObject);
            var tickets = new HashSet<Ticket>() {
                pruebaTestticket
            };
            repository.Expects.One.Method(c => c.GetAll()).WillReturn(tickets);
            repository.Expects.One.Method(c => c.Get(pruebaTest)).WillReturn(pruebaTestticket);
            unitOfWork.Expects.One.Method(c => c.Dispose());
            //Act
            var result = ticketService.GetAll().ToList();
            ticketService.Add(pruebaTestticket);
            //Assert
            Assert.AreEqual(pruebaTest, result.Count());
            Assert.AreEqual(pruebaTestticket, result[0]);
        }
    }
}