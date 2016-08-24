using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedicSystem.Models;

namespace MedicSystem.ViewModels
{
    public class MedicosCreateViewModel
    {
        public DadosPessoais dados;
        public Enderecos endereco;
        public Medicos medico;

        public MedicosCreateViewModel()
        {
            this.dados = new DadosPessoais();
            this.endereco = new Enderecos();
            this.medico = new Medicos();
        }

        public MedicosCreateViewModel(DadosPessoais pdados, Enderecos pendereco, Medicos pmedico)
        {
            this.dados = pdados;
            this.endereco = pendereco;
            this.medico = pmedico;
        }
    }

}