using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceWCF
{
    [ServiceContract]
    public interface IServiceTicket
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Ticket Add(Ticket ticket);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/{id}", ResponseFormat = WebMessageFormat.Json)]
        Ticket Get(int id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "", ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<Ticket> GetAll();

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void Update(Ticket ticket);
    }
}
