using Domain;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceWCF
{
    public class ServiceArticle : ServiceBase, IServiceArticle
    {
        readonly IRepositoryArticle _repository;
        public ServiceArticle(IRepositoryArticle repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            if (null == repository)
            {
                throw new ArgumentNullException("repository");
            }
            _repository = repository;
        }
        public IEnumerable<Article> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
