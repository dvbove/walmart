using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Walmart.Prova.Model
{
    [Serializable]
    public class Cidade
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public int CodigoEstado { get; set; }
        public Estado Estado { get; set; }
        public List<Estado> Estados { get; set; }


        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public bool Capital { get; set; }
    }
}
