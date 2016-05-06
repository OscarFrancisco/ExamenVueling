using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("SaleArticle")]
    public class SaleArticle : EntityBase
    {
        public int Quantity { get; set; }
        public decimal PriceSale { get; set; }
        public Article ArticleSale { get; set; }
    }
}
