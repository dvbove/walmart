using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Xml;

namespace Walmart.Prova.Data.Repositorio.XML
{
    public class EstadoXML : IEstado
    {
        #region :: Propriedades ::
        private string path;
        #endregion

        #region :: Metodos ::
        /// <summary>
        /// Construtor
        /// </summary>
        public EstadoXML()
        {
            path = Configuracao.DiretorioXML + "/Estado.xml";

            if (!System.IO.Directory.Exists(Configuracao.DiretorioXML))
            {
                System.IO.Directory.CreateDirectory(Configuracao.DiretorioXML);
            }
        }

        /// <summary>
        /// Retorna a lista de estados gravados.
        /// </summary>
        /// <returns>Lista de estados</returns>
        public List<Model.Estado> Listar()
        {
            if (System.IO.File.Exists(path))
            {
                XDocument doc = XDocument.Load(path);

                List<Model.Estado> estados = new List<Model.Estado>();

                foreach (XElement element in doc.Descendants("Estado"))
                {
                    Model.Estado estado = new Model.Estado();

                    estado.Codigo = Convert.ToInt32(element.Element("Codigo").Value);
                    estado.Pais = element.Element("Pais").Value;
                    estado.Nome = element.Element("Nome").Value;
                    estado.Regiao = element.Element("Regiao").Value;
                    estado.Sigla = element.Element("Sigla").Value;

                    estados.Add(estado);
                }
            }
            return null;
        }

        /// <summary>
        /// Obter o estado correspondente ao código informado.
        /// </summary>
        /// <param name="codigo">Código do estado</param>
        /// <returns>Estado</returns>
        public Model.Estado Obter(int codigo)
        {
            Model.Estado estado = null;

            if (System.IO.File.Exists(path))
            {
                XDocument doc = XDocument.Load(path);

                foreach (var element in doc.Descendants("Estado"))
                {
                    if (Convert.ToInt32(element.Element("Codigo").Value) == codigo)
                    {
                        estado = new Model.Estado();

                        estado.Codigo = Convert.ToInt32(element.Element("Codigo").Value);
                        estado.Pais = element.Element("Pais").Value;
                        estado.Nome = element.Element("Nome").Value;
                        estado.Regiao = element.Element("Regiao").Value;
                        estado.Sigla = element.Element("Sigla").Value;

                        break;
                    }
                }
            }

            return estado;
        }

        /// <summary>
        /// Grava o estado
        /// </summary>
        /// <param name="estado">Objeto do estado</param>
        /// <returns>Código do estado gravado</returns>
        public int Gravar(Model.Estado estado)
        {
            XmlDocument doc = new XmlDocument();

            if (!System.IO.File.Exists(path))
            {
                var fs = File.Create(path);
                fs.Close();

                System.IO.StreamWriter writer = new StreamWriter(path);
                writer.WriteLine(@"<Estados></Estados>");
                writer.Close();
            }

            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(file);
            file.Close();

            int novoId = ObterProximoId();

            XmlElement novoEstado = xmlDoc.CreateElement("Estado");

            XmlElement idElement = xmlDoc.CreateElement("Codigo");
            idElement.InnerText = novoId.ToString();
            novoEstado.AppendChild(idElement);

            XmlElement paisElement = xmlDoc.CreateElement("Pais");
            paisElement.InnerText = estado.Nome;
            novoEstado.AppendChild(paisElement);

            XmlElement nomeElement = xmlDoc.CreateElement("Nome");
            nomeElement.InnerText = estado.Nome;
            novoEstado.AppendChild(nomeElement);

            XmlElement regiaoElement = xmlDoc.CreateElement("Regiao");
            regiaoElement.InnerText = estado.Regiao;
            novoEstado.AppendChild(regiaoElement);

            XmlElement siglaElement = xmlDoc.CreateElement("Sigla");
            siglaElement.InnerText = estado.Sigla;
            novoEstado.AppendChild(siglaElement);

            xmlDoc.DocumentElement.InsertAfter(novoEstado, xmlDoc.DocumentElement.LastChild);

            FileStream fsxml = new FileStream(path,
                                              FileMode.Truncate,
                                              FileAccess.Write,
                                              FileShare.ReadWrite);

            xmlDoc.Save(fsxml);
            fsxml.Close();

            return novoId;
        }

        /// <summary>
        /// Atualizar o estado.
        /// </summary>
        /// <param name="estado">Objeto estado</param>
        /// <returns>true ou false para o procedimento</returns>
        public bool Atualizar(Model.Estado estado)
        {
            bool atualizou = false;

            if (System.IO.File.Exists(path))
            {
                XDocument doc = XDocument.Load(path);

                foreach (var item in doc.Descendants("Estado"))
                {
                    if (Convert.ToInt32(item.Element("Codigo").Value) == estado.Codigo)
                    {
                        item.Element("Nome").SetValue(estado.Nome);
                        item.Element("Pais").SetValue(estado.Pais);
                        item.Element("Regiao").SetValue(estado.Regiao);
                        item.Element("Sigla").SetValue(estado.Sigla);
                        doc.Save(path);

                        atualizou = true;
                        break;
                    }
                }
            }

            return atualizou;
        }

        /// <summary>
        /// Apaga o estado corresondente ao código informado.
        /// </summary>
        /// <param name="codigo">Código do estado</param>
        /// <returns>true ou false para o procedimento</returns>
        public bool Apagar(int codigo)
        {
            bool apagou = false;

            if (System.IO.File.Exists(path))
            {
                XDocument doc = XDocument.Load(path);

                foreach (var element in doc.Descendants("Estado"))
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

        #region :: Auxiliares ::
        /// <summary>
        /// Obter o proximo ID disponivel para gravação
        /// </summary>
        /// <returns></returns>
        private int ObterProximoId()
        {
            if (File.Exists(path))
            {
                XDocument doc = XDocument.Load(path);

                if (doc.Descendants("Estado").Count() > 0)
                {

                    var ajuste = (from a in doc.Descendants("Estado")
                                  orderby Convert.ToInt32(a.Element("Codigo").Value) descending
                                  select Convert.ToInt32(a.Element("Codigo").Value)).First();

                    return ajuste + 1;
                }
            }

            return 1;
        }
        #endregion
    }
}
