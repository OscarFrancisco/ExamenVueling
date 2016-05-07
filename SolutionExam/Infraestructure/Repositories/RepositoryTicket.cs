using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public class RepositoryTicket : RepositoryBase<Ticket>, IRepositoryTicket
    {
        public RepositoryTicket(IDbContext context) : base(context) { }
        public Ticket Add(Ticket ticket)
        {
            Entity.Add(ticket);
            return ticket;
        }
        public Ticket Get(int id)
        {
            return Entity.Where(_ => _.Id == id).FirstOrDefault();
        }
        public IEnumerable<Ticket> GetAll()
        {
            return Entity;
        }
        public void Update(Ticket ticket)
        {
            Modify(ticket);
        }
    }
}
