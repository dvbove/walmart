using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Walmart.Prova.WebService
{
    public class Cidade : ICidade
    {
        public string Add(Model.Cidade cidade)
        {
            Walmart.Prova.Service.Business.Cidade cidadeBusiness = new Walmart.Prova.Service.Business.Cidade();
            return cidadeBusiness.Gravar(cidade).ToString();
        }

        public string Update(Model.Cidade cidade)
        {
            Walmart.Prova.Service.Business.Cidade cidadeBusiness = new Walmart.Prova.Service.Business.Cidade();
            cidadeBusiness.Atualizar(cidade);

            return "Ok";
        }

        public string Delete(int id)
        {
            Walmart.Prova.Service.Business.Cidade cidadeBusiness = new Walmart.Prova.Service.Business.Cidade();
            cidadeBusiness.Apagar(id);

            return "Ok";
        }

        public Model.Cidade Get(string id)
        {
            Walmart.Prova.Service.Business.Cidade cidadeBusiness = new Walmart.Prova.Service.Business.Cidade();
            return cidadeBusiness.Obter(Convert.ToInt32(id));
        }
    }
}
