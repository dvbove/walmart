using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Walmart.Prova.WebService
{
    [ServiceContract]
    public interface ICidade
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/cidades/add")]
        string Add(Model.Cidade cidade);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/cidades")]
        string Update(Model.Cidade cidade);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/cidades")]
        string Delete(int id);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/cidades/{id}")]
        Model.Cidade Get(string id);
    }
}
