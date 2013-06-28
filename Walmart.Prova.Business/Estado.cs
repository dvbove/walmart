using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Walmart.Prova.Data.Fabrica;

namespace Walmart.Prova.Site.Business
{
    public static class Estado
    {
        /// <summary>
        /// Lista todas as estados.
        /// </summary>
        /// <returns>Lista de estados</returns>
        public static List<Model.Estado> Listar()
        {
            var repositorio = FabricaDeRepositorios.ObtemRepositorioEstados();

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
        /// Obtem o estado correspondente ao código informado
        /// </summary>
        /// <param name="codigo">Código da estado</param>
        /// <returns>Estado</returns>
        public static Model.Estado Obter(int codigo)
        {
            var repositorio = FabricaDeRepositorios.ObtemRepositorioEstados();

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
        /// Gravar um novo registro de estado
        /// </summary>
        /// <param name="estado">Estado para gravar</param>
        /// <returns>true ou false para o procedimento</returns>
        public static int Gravar(Model.Estado estado)
        {
            var repositorio = FabricaDeRepositorios.ObtemRepositorioEstados();

            try
            {
                return repositorio.Gravar(estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Atualiza os dados do estado
        /// </summary>
        /// <param name="estado">Estado para atualilzar</param>
        /// <returns>true ou false para o procedimento</returns>
        public static bool Atualizar(Model.Estado estado)
        {
            var repositorio = FabricaDeRepositorios.ObtemRepositorioEstados();

            try
            {
                return repositorio.Atualizar(estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Apaga o estado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns>true ou false para o procedimento</returns>
        public static bool Apagar(int codigo)
        {
            var repositorio = FabricaDeRepositorios.ObtemRepositorioEstados();

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
