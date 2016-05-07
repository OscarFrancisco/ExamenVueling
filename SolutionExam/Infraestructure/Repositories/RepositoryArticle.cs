using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public class RepositoryArticle : RepositoryBase<Article>, IRepositoryArticle
    {
        public RepositoryArticle(IDbContext context) : base(context) { }
        public IEnumerable<Article> GetAll()
        {
            return Entity.Select(_ => _).ToList();
        }
    }
}
