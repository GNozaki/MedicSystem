using MedicSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicSystem.ViewModels
{
    public class PacientesCreateViewModel
    {
        public DadosPessoais dados;        
        public Enderecos endereco;

        public PacientesCreateViewModel()
        {
            this.dados = new DadosPessoais();            
            this.endereco = new Enderecos();
        }

        public PacientesCreateViewModel(DadosPessoais pdados, Enderecos pendereco)
        {
            this.dados = pdados;
            this.endereco = pendereco;
        }
    }
}