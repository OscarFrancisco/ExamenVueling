using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Ticket")]
    public class Ticket : EntityBase
    {
        public List<SaleArticle> Articles{get;set;}
        public DateTime DateTicket;
    }
}
