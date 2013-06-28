using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Xml;

namespace Walmart.Prova.Data.Repositorio.XML
{
    public class CidadeXML : ICidade
    {
        #region :: Propriedades ::
        private string path;
        #endregion

        #region :: Metodos ::
        /// <summary>
        /// Construtor
        /// </summary>
        public CidadeXML()
        {
            path = Configuracao.DiretorioXML + "/Cidade.xml";

            if (!System.IO.Directory.Exists(Configuracao.DiretorioXML))
            {
                System.IO.Directory.CreateDirectory(Configuracao.DiretorioXML);
            }
        }

        /// <summary>
        /// Retorna a lista de cidades gravadas.
        /// </summary>
        /// <returns>Lista de cidades</returns>
        public List<Model.Cidade> Listar()
        {
            if (System.IO.File.Exists(path))
            {
                XDocument doc = XDocument.Load(path);

                List<Model.Cidade> cidades = new List<Model.Cidade>();

                foreach (XElement element in doc.Descendants("Cidade"))
                {
                    Model.Cidade cidade = new Model.Cidade();

                    cidade.Codigo = Convert.ToInt32(element.Element("Codigo").Value);
                    cidade.Nome = element.Element("Nome").Value;
                    cidade.CodigoEstado = Convert.ToInt32(element.Element("CodigoEstado").Value);
                    cidade.Capital = Convert.ToBoolean(element.Element("Capital").Value);

                    EstadoXML estadoData = new EstadoXML();
                    cidade.Estado = estadoData.Obter(cidade.CodigoEstado);

                    cidades.Add(cidade);
                }
            }
            return null;
        }

        /// <summary>
        /// Obter a cidade correspondente ao código informado.
        /// </summary>
        /// <param name="codigo">Código da cidade</param>
        /// <returns>Cidade</returns>
        public Model.Cidade Obter(int codigo)
        {
            Model.Cidade cidade = null;

            if (System.IO.File.Exists(path))
            {
                XDocument doc = XDocument.Load(path);

                foreach (var element in doc.Descendants("Cidade"))
                {
                    if (Convert.ToInt32(element.Element("Codigo").Value) == codigo)
                    {
                        cidade = new Model.Cidade();

                        cidade.Codigo = Convert.ToInt32(element.Element("Codigo").Value);
                        cidade.Nome = element.Element("Nome").Value;
                        cidade.CodigoEstado = Convert.ToInt32(element.Element("CodigoEstado").Value);
                        cidade.Capital = Convert.ToBoolean(element.Element("Capital").Value);

                        EstadoXML estadoData = new EstadoXML();
                        cidade.Estado = estadoData.Obter(cidade.CodigoEstado);

                        break;
                    }
                }
            }

            return cidade;
        }

        /// <summary>
        /// Grava a cidade
        /// </summary>
        /// <param name="cidade">Objeto do cidade</param>
        /// <returns>Código do cidade gravado</returns>
        public int Gravar(Model.Cidade cidade)
        {
            XmlDocument doc = new XmlDocument();

            if (!System.IO.File.Exists(path))
            {
                var fs = File.Create(path);
                fs.Close();

                System.IO.StreamWriter writer = new StreamWriter(path);
                writer.WriteLine(@"<Cidades></Cidades>");
                writer.Close();
            }

            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(file);
            file.Close();

            XmlElement novaCidade = xmlDoc.CreateElement("Cidade");

            XmlElement idElement = xmlDoc.CreateElement("Codigo");
            idElement.InnerText = cidade.Codigo.ToString();
            novaCidade.AppendChild(idElement);

            XmlElement codigoEstado = xmlDoc.CreateElement("CodigoEstado");
            codigoEstado.InnerText = cidade.CodigoEstado.ToString();
            novaCidade.AppendChild(codigoEstado);

            XmlElement nome = xmlDoc.CreateElement("Nome");
            nome.InnerText = cidade.Nome;
            novaCidade.AppendChild(nome);

            XmlElement capital = xmlDoc.CreateElement("Capital");
            capital.InnerText = cidade.Capital.ToString();
            novaCidade.AppendChild(capital);

            xmlDoc.DocumentElement.InsertAfter(novaCidade, xmlDoc.DocumentElement.LastChild);

            FileStream fsxml = new FileStream(path,
                                              FileMode.Truncate,
                                              FileAccess.Write,
                                              FileShare.ReadWrite);

            xmlDoc.Save(fsxml);
            fsxml.Close();

            return cidade.Codigo;
        }

        /// <summary>
        /// Atualizar o cidade.
        /// </summary>
        /// <param name="cidade">Objeto cidade</param>
        /// <returns>true ou false para o procedimento</returns>
        public bool Atualizar(Model.Cidade cidade)
        {
            bool atualizou = false;

            if (System.IO.File.Exists(path))
            {
                XDocument doc = XDocument.Load(path);

                foreach (var item in doc.Descendants("Cidade"))
                {
                    if (Convert.ToInt32(item.Element("Codigo").Value) == cidade.Codigo)
                    {
                        item.Element("Nome").SetValue(cidade.Nome);
                        item.Element("Capital").SetValue(cidade.Capital);
                        item.Element("CodigoEstado").SetValue(cidade.CodigoEstado);

                        doc.Save(path);

                        atualizou = true;
                        break;
                    }
                }
            }

            return atualizou;
        }

        /// <summary>
        /// Apaga o cidade corresondente ao código informado.
        /// </summary>
        /// <param name="codigo">Código do cidade</param>
        /// <returns>true ou false para o procedimento</returns>
        public bool Apagar(int codigo)
        {
            bool apagou = false;

            if (System.IO.File.Exists(path))
            {
                XDocument doc = XDocument.Load(path);

                foreach (var element in doc.Descendants("Cidade"))
                {
                    if (Convert.ToInt32(element.Element("Codigo").Value) == codigo)
                    {
                        element.Element("Codigo").Parent.Remove();
                        doc.Save(path);

                        apagou = true;
                        break;
                    }
                }
            }

            return apagou;
        }
        #endregion
    }
}
