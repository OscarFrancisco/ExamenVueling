using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Aritcle")]
    public class Article : EntityBase
    {
		public string Description {get; set;}
        public decimal Price { get; set;}
    }
}
