using Domain;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceWCF
{
    public class ServiceTicket : ServiceBase, IServiceTicket
    {
        readonly IRepositoryTicket _repository;
        public ServiceTicket(IRepositoryTicket repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            if (null == repository)
            {
                throw new ArgumentNullException("repository");
            }
            _repository = repository;
        }
        public Ticket Add(Ticket ticket)
        {
            foreach (var item in ticket.Articles)
            {
                item.PriceSale = item.ArticleSale.Price;
            }
            var ticketnew = _repository.Add(ticket);
            Save();
            return ticketnew;
        }
        public Ticket Get(string id)
        {
            int OutId;
            int.TryParse(id, out OutId);
            return _repository.Get(OutId);
        }
        public IEnumerable<Ticket> GetAll()
        {
            return _repository.GetAll();
        }
        public void Update(Ticket ticket)
        {
            _repository.Update(ticket);
            Save();
        }
    }
}
