using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Walmart.Prova.Data.Repositorio
{
    public interface IEstado
    {
        List<Model.Estado> Listar();
        Model.Estado Obter(int codigo);
        int Gravar(Model.Estado estado);
        bool Atualizar(Model.Estado estado);
        bool Apagar(int codigo);
    }
}
