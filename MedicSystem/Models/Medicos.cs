using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicSystem.Models
{
    public class Medicos
    {
        [Key]
        public long MedicoId { get; set; }

        public string Crm { get; set; }

        public string Especialidade { get; set; }

        public long? EnderecoId { get; set; }

        public long DadosPessoaisId { get; set; }

        [ForeignKey("EnderecoId")]
        public Enderecos Endereco { get; set; }

        [ForeignKey("DadosPessoaisId")]
        public DadosPessoais Dados { get; set; }
    }
}