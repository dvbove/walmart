using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Walmart.Prova.Data
{
    internal class Configuracao
    {
        /// <summary>
        /// Tipo de repositorio do site.
        /// </summary>
        internal static string TipoRepositorio
        {
            get
            {
                var tipoRepositorio = System.Configuration.ConfigurationManager.AppSettings["Walmart.Prova.Web.TipoRepositorio"];

                if (tipoRepositorio == null || string.IsNullOrEmpty(tipoRepositorio.ToString()))
                {
                    throw new ApplicationException("O tipo de repositório não foi preenchido no arquivo de configuração.");
                }

                return tipoRepositorio.ToString();
            }
        }

        /// <summary>
        /// String de conexão do site.
        /// </summary>
        internal static string ConnectionString
        {
            get
            {
                var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Walmart.Prova.Web.ConectionString"];

                if (connectionString == null || string.IsNullOrEmpty(connectionString.ToString()))
                {
                    throw new ApplicationException("A connection string não foi preenchida no arquivo de configuração.");
                }

                return connectionString.ToString();
            }
        }

        /// <summary>
        /// Parametrização do diretório de armazenamento dos arquivos de XML.
        /// </summary>
        internal static string DiretorioXML
        {
            get
            {
                var diretorio = System.Configuration.ConfigurationManager.AppSettings["Walmart.Prova.Web.DiretorioXML"];

                if (diretorio == null || string.IsNullOrEmpty(diretorio.ToString()))
                {
                    throw new ApplicationException("O diretório XML não foi preenchido no arquivo de configuração.");
                }

                return diretorio.ToString();
            }
        }
    }
}
