using Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceWCF
{
    public class ServiceBase
    {
        readonly IUnitOfWork _unitOfWork;
        public ServiceBase(IUnitOfWork unitOfWork)
        {
            if (null == unitOfWork)
            {
                throw new ArgumentNullException("unitOfWork");
            }
            _unitOfWork = unitOfWork;
        }
        protected int Save()
        {
            return _unitOfWork.SaveChanges();
        }
    }
}