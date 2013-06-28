using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Walmart.Prova.Data.Fabrica;

namespace Walmart.Prova.Service.Business
{
    public class Cidade
    {
        /// <summary>
        /// Lista todas as cidades.
        /// </summary>
        /// <returns>Lista de cidades</returns>
        public List<Model.Cidade> Listar()
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
        public Model.Cidade Obter(int codigo)
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
        public int Gravar(Model.Cidade cidade)
        {
            var repositorio = FabricaDeRepositorios.ObtemRepositorioCidades();

            try
            {
                return repositorio.Gravar(cidade);
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
        public bool Atualizar(Model.Cidade cidade)
        {
            var repositorio = FabricaDeRepositorios.ObtemRepositorioCidades();

            try
            {
                return repositorio.Atualizar(cidade);
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
        public bool Apagar(int codigo)
        {
            var repositorio = FabricaDeRepositorios.ObtemRepositorioCidades();

            try
            {
                return repositorio.Apagar(codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
