using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MedicSystem.Models
{
    public class MedicalContext : DbContext
    {
        public DbSet<Clinicas> Clinicas { get; set; }

        public DbSet<Enderecos> Enderecos { get; set; }

        public DbSet<Medicos> Medicos { get; set; }

        public DbSet<Pacientes> Pacientes { get; set; }

        public DbSet<DadosPessoais> DadosPessoais { get; set; }
    }
}