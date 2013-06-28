using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Walmart.Prova.Model
{
    public class Estado
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Sigla { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Regiao { get; set; }
    }
}
