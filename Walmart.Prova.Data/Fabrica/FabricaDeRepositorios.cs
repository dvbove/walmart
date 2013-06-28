using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Walmart.Prova.Data.Repositorio;
using Walmart.Prova.Data.Repositorio.SQL;
using Walmart.Prova.Data.Repositorio.XML;

namespace Walmart.Prova.Data.Fabrica
{
    /// <summary>
    /// Concretiza os repositórios
    /// </summary>
    public class FabricaDeRepositorios
    {
        /// Retorna um repositório concreto de estados, baseado no padrão de configuração contido em: Configuracao.TipoRepositorio
        /// </summary>
        /// <returns>Repositorio de estados</returns>
        public static IEstado ObtemRepositorioEstados()
        {
            string escolha = Configuracao.TipoRepositorio;

            switch (escolha)
            {
                case "SQL": return new EstadoSQL();
                case "XML": return new EstadoXML();
            }

            return null;
        }

        /// Retorna um repositório concreto de cidades, baseado no padrão de configuração contido em: Configuracao.TipoRepositorio
        /// </summary>
        /// <returns>Repositorio de cidades</returns>
        public static ICidade ObtemRepositorioCidades()
        {
            string escolha = Configuracao.TipoRepositorio;

            switch (escolha)
            {
                case "SQL": return new CidadeSQL();
                case "XML": return new CidadeXML();
            }

            return null;
        }
    }
}
