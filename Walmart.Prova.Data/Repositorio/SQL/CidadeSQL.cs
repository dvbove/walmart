using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Walmart.Prova.Data.Repositorio.SQL
{
    public class CidadeSQL : ICidade
    {
        /// <summary>
        /// Retorna a lista de cidades gravadas.
        /// </summary>
        /// <returns>Lista de cidades</returns>
        public List<Model.Cidade> Listar()
        {
            List<Model.Cidade> cidades = new List<Model.Cidade>();
            DataTable dt = Util.GetDataTable("SELECT Id, IdEstado, Nome, Capital FROM Cidade ");

            foreach (DataRow dr in dt.Rows)
            {
                Model.Cidade cidade = new Model.Cidade();

                if (!dr.IsNull("Id"))
                    cidade.Codigo = Convert.ToInt32(dr["Id"]);

                if (!dr.IsNull("Nome"))
                    cidade.Nome = dr["Nome"].ToString();

                if (!dr.IsNull("Capital"))
                    cidade.Capital = Convert.ToBoolean(dr["Capital"]);


                if (!dr.IsNull("IdEstado"))
                    cidade.CodigoEstado = Convert.ToInt32(dr["IdEstado"]);

                EstadoSQL dataEstado = new EstadoSQL();
                cidade.Estado = dataEstado.Obter(cidade.CodigoEstado);


                cidades.Add(cidade);
            }

            return cidades;
        }

        /// <summary>
        /// Obter a cidade correspondente ao código informado.
        /// </summary>
        /// <param name="codigo">Código do estado</param>
        /// <returns>Cidade</returns>
        public Model.Cidade Obter(int codigo)
        {
            using (IDataReader reader = Util.GetIDataReader("SELECT Id, IdEstado, Nome, Capital FROM Cidade WHERE Id = " + codigo.ToString()))
            {
                Model.Cidade cidade = null;

                if (reader.Read())
                {
                    cidade = new Model.Cidade();
                    cidade.Codigo = Convert.ToInt32(reader["Id"]);
                    cidade.CodigoEstado = Convert.ToInt32(reader["IdEstado"]);
                    cidade.Nome = reader["Nome"].ToString();
                    cidade.Capital = Convert.ToBoolean(reader["Capital"].ToString());

                    EstadoSQL dataEstado = new EstadoSQL();
                    cidade.Estado = dataEstado.Obter(cidade.CodigoEstado);
                }

                return cidade;
            }
        }

        /// <summary>
        /// Grava a cidade
        /// </summary>
        /// <param name="estado">Objeto do cidade</param>
        /// <returns>Código do cidade gravado</returns>
        public int Gravar(Model.Cidade cidade)
        {
            StringBuilder st = new StringBuilder();
            st.Append("INSERT INTO ");
            st.Append("Cidade (");
            st.Append("IdEstado, Nome, Capital");
            st.Append(")");
            st.Append("VALUES (");
            st.Append("@IdEstado, @Nome, @Capital ");
            st.Append(");");
            st.Append(" SELECT @@IDENTITY; ");

            SqlParameter estado = new SqlParameter();
            estado.ParameterName = "@IdEstado";
            estado.Value = cidade.CodigoEstado;

            SqlParameter nome = new SqlParameter();
            nome.ParameterName = "@Nome";
            nome.Value = cidade.Nome;

            SqlParameter capital = new SqlParameter();
            capital.ParameterName = "@Capital";
            capital.Value = cidade.Capital;

            return Convert.ToInt32(Util.ExecuteScalar(st.ToString(), estado, nome, capital));
        }

        /// <summary>
        /// Atualizar o cidade.
        /// </summary>
        /// <param name="cidade">Objeto cidade</param>
        /// <returns>true ou false para o procedimento</returns>
        public bool Atualizar(Model.Cidade cidade)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE Cidade SET ");
            sql.Append("IdEstado = ");
            sql.Append("@IdEstado");
            sql.Append(", ");
            sql.Append("Nome = ");
            sql.Append("@Nome");
            sql.Append(", ");
            sql.Append("Capital = ");
            sql.Append("@Capital");
            sql.Append(" WHERE (id = ");
            sql.Append("@Id");
            sql.Append(")");

            SqlParameter estado = new SqlParameter();
            estado.ParameterName = "@IdEstado";
            estado.DbType = DbType.Int32;
            estado.Value = cidade.CodigoEstado;

            SqlParameter nome = new SqlParameter();
            nome.ParameterName = "@Nome";
            nome.Value = cidade.Nome;

            SqlParameter capital = new SqlParameter();
            capital.ParameterName = "@Capital";
            capital.DbType = DbType.Boolean;
            capital.Value = cidade.Capital;

            SqlParameter codigo = new SqlParameter();
            codigo.ParameterName = "@Id";
            codigo.Value = cidade.Codigo;

            var rows = Util.ExecuteNonQuery(sql.ToString(), estado, nome, capital, codigo);

            return rows > 0;
        }

        /// <summary>
        /// Apaga o cidade corresondente ao código informado.
        /// </summary>
        /// <param name="codigo">Código do cidade</param>
        /// <returns>true ou false para o procedimento</returns>
        public bool Apagar(int codigo)
        {
            SqlParameter id = new SqlParameter();
            id.ParameterName = "@Id";
            id.DbType = DbType.Int32;
            id.Value = codigo;

            var rows = Util.ExecuteNonQuery("DELETE FROM Cidade WHERE id = @Id", id);

            return rows > 0;
        }
    }
}
