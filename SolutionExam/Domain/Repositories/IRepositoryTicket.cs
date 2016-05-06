using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRepositoryTicket
    {
        Ticket Add(Ticket ticket);
        Ticket Get(int id);
        IEnumerable<Ticket> GetAll();
    }
}
