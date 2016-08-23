using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedicSystem.Models
{
    public class DadosPessoais
    {
        [Key]
        public long DadosId { get; set; }

        public string Cpf { get; set; }

        [Required]
        public string Nome { get; set; }

        public DateTime Nascimento { get; set; } 
    }
}