using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MedicSystem.Models
{
    public class Clinicas
    {
        [Key]
        public long ClinicaId { get; set; }

        public string Nome { get; set; }

        public long? EnderecoId { get; set; }

        [ForeignKey("EnderecoId")]
        public Enderecos Endereco { get; set; }

        public virtual ICollection<Medicos> Medicos { get; set; }
    }
}