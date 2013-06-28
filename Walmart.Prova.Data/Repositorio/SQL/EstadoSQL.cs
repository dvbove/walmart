using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Walmart.Prova.Model;
using System.Data.SqlClient;

namespace Walmart.Prova.Data.Repositorio.SQL
{
    public class EstadoSQL : IEstado
    {
        /// <summary>
        /// Retorna a lista de estados gravados.
        /// </summary>
        /// <returns>Lista de estados</returns>
        public List<Model.Estado> Listar()
        {
            List<Model.Estado> estados = new List<Model.Estado>();
            DataTable dt = Util.GetDataTable("SELECT Id, Pais, Nome, Sigla, Regiao FROM Estado ");

            foreach (DataRow dr in dt.Rows)
            {
                Model.Estado estado = new Model.Estado();

                if (!dr.IsNull("Id"))
                    estado.Codigo = Convert.ToInt32(dr["Id"]);

                if (!dr.IsNull("Pais"))
                    estado.Pais = dr["Pais"].ToString();

                if (!dr.IsNull("Nome"))
                    estado.Nome = dr["Nome"].ToString();

                if (!dr.IsNull("Sigla"))
                    estado.Sigla = dr["Sigla"].ToString();

                if (!dr.IsNull("Regiao"))
                    estado.Regiao = dr["Regiao"].ToString();

                estados.Add(estado);
            }

            return estados;
        }

        /// <summary>
        /// Obter o estado correspondente ao código informado.
        /// </summary>
        /// <param name="codigo">Código do estado</param>
        /// <returns>Estado</returns>
        public Model.Estado Obter(int codigo)
        {
            using (IDataReader reader = Util.GetIDataReader("SELECT Id, Pais, Nome, Sigla, Regiao  FROM Estado WHERE Id = " + codigo.ToString()))
            {
                Estado estado = null;

                if (reader.Read())
                {
                    estado = new Estado();
                    estado.Codigo = Convert.ToInt32(reader["Id"]);
                    estado.Pais = reader["Pais"].ToString();
                    estado.Nome = reader["Nome"].ToString();
                    estado.Sigla = reader["Sigla"].ToString();
                    estado.Regiao = reader["Regiao"].ToString();
                }

                return estado;
            }
        }

        /// <summary>
        /// Grava o estado
        /// </summary>
        /// <param name="estado">Objeto do estado</param>
        /// <returns>Código do estado gravado</returns>
        public int Gravar(Model.Estado estado)
        {
            StringBuilder st = new StringBuilder();
            st.Append("INSERT INTO ");
            st.Append("Estado (");
            st.Append("Pais, Nome, Sigla, Regiao");
            st.Append(")");
            st.Append("VALUES (");
            st.Append("@Pais, @Nome, @Sigla, @Regiao ");
            st.Append(");");
            st.Append(" SELECT @@IDENTITY; ");

            SqlParameter pais = new SqlParameter();
            pais.ParameterName = "@Pais";
            pais.Value = estado.Pais;

            SqlParameter nome = new SqlParameter();
            nome.ParameterName = "@Nome";
            nome.Value = estado.Nome;

            SqlParameter sigla = new SqlParameter();
            sigla.ParameterName = "@Sigla";
            sigla.Value = estado.Sigla;

            SqlParameter regiao = new SqlParameter();
            regiao.ParameterName = "@Regiao";
            regiao.Value = estado.Regiao;

            return Convert.ToInt32(Util.ExecuteScalar(st.ToString(), pais, nome, sigla, regiao));
        }

        /// <summary>
        /// Atualizar o estado.
        /// </summary>
        /// <param name="estado">Objeto estado</param>
        /// <returns>true ou false para o procedimento</returns>
        public bool Atualizar(Model.Estado estado)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE Estado SET ");
            sql.Append("Pais = '");
            sql.Append("@Pais");
            sql.Append("', ");
            sql.Append("Nome = '");
            sql.Append("@Nome");
            sql.Append("', ");
            sql.Append("Sigla = ");
            sql.Append("@Sigla");
            sql.Append(", ");
            sql.Append("Regiao = ");
            sql.Append("@Regiao");
            sql.Append(" WHERE (id = ");
            sql.Append("@Id");
            sql.Append(")");

            SqlParameter pais = new SqlParameter();
            pais.ParameterName = "@Pais";
            pais.Value = estado.Pais;

            SqlParameter nome = new SqlParameter();
            nome.ParameterName = "@Nome";
            nome.Value = estado.Pais;

            SqlParameter sigla = new SqlParameter();
            sigla.ParameterName = "@Sigla";
            sigla.Value = estado.Pais;

            SqlParameter regiao = new SqlParameter();
            regiao.ParameterName = "@Regiao";
            regiao.Value = estado.Pais;

            SqlParameter codigo = new SqlParameter();
            codigo.ParameterName = "@Id";
            codigo.Value = estado.Codigo;

            var rows = Util.ExecuteNonQuery(sql.ToString(), pais, nome, sigla, regiao, codigo);

            return rows > 0;
        }

        /// <summary>
        /// Apaga o estado corresondente ao código informado.
        /// </summary>
        /// <param name="codigo">Código do estado</param>
        /// <returns>true ou false para o procedimento</returns>
        public bool Apagar(int codigo)
        {
            SqlParameter id = new SqlParameter();
            id.ParameterName = "@Id";
            id.Value = codigo;

            var rows = Util.ExecuteNonQuery("DELETE FROM Estado WHERE Id = @Id", id);

            return rows > 0;
        }
    }
}
