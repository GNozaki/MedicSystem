using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedicSystem.Models
{
    public class Enderecos
    {
        [Key]
        public long EnderecoId { get; set; }

        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string NumeroLocal { get; set; }
        public string Cep { get; set; }

    }
}