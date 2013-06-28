using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Walmart.Prova.Data.Repositorio
{
    public interface ICidade
    {
        List<Model.Cidade> Listar();
        Model.Cidade Obter(int codigo);
        int Gravar(Model.Cidade cidade);
        bool Atualizar(Model.Cidade cidade);
        bool Apagar(int codigo);
    }
}
