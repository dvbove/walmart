using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Walmart.Prova.Data.Fabrica;
using Walmart.Prova.Business.CidadeService;

namespace Walmart.Prova.Site.Business
{
    public static class Cidade
    {
        /// <summary>
        /// Lista todas as cidades.
        /// </summary>
        /// <returns>Lista de cidades</returns>
        public static List<Model.Cidade> Listar()
        {
            var repositorio = FabricaDeRepositorios.ObtemRepositorioCidades();

            try
            {
                return repositorio.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtem a cidade correspondente ao código informado
        /// </summary>
        /// <param name="codigo">Código da cidade</param>
        /// <returns>Cidade</returns>
        public static Model.Cidade Obter(int codigo)
        {
            var repositorio = FabricaDeRepositorios.ObtemRepositorioCidades();

            try
            {
                return repositorio.Obter(codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gravar um novo registro de cidade
        /// </summary>
        /// <param name="cidade">Cidade para gravar</param>
        /// <returns>true ou false para o procedimento</returns>
        public static int Gravar(Model.Cidade cidade)
        {
            var repositorio = FabricaDeRepositorios.ObtemRepositorioCidades();

            try
            {
                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
                    var id = repositorio.Gravar(cidade);
                    cidade.Codigo = id;

                    CidadeClient service = new CidadeClient();
                    service.Add(cidade);

                    ts.Complete();

                    return cidade.Codigo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Atualiza os dados da cidade
        /// </summary>
        /// <param name="cidade">Cidade para atualilzar</param>
        /// <returns>true ou false para o procedimento</returns>
        public static bool Atualizar(Model.Cidade cidade)
        {
            var repositorio = FabricaDeRepositorios.ObtemRepositorioCidades();

            try
            {
                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
                    var atualizou = repositorio.Atualizar(cidade);

                    CidadeClient service = new CidadeClient();
                    service.Update(cidade);

                    ts.Complete();

                    return atualizou;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Apaga a cidade
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns>true ou false para o procedimento</returns>
        public static bool Apagar(int codigo)
        {
            var repositorio = FabricaDeRepositorios.ObtemRepositorioCidades();

            try
            {
                using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
                {
                    var apagou = repositorio.Apagar(codigo);

                    CidadeClient service = new CidadeClient();
                    service.Delete(codigo);

                    ts.Complete();

                    return apagou;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
