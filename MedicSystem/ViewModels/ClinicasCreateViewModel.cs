using MedicSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicSystem.ViewModels
{
    public class ClinicasCreateViewModel
    {
        public Clinicas clinica;
        public Enderecos endereco;

        public ClinicasCreateViewModel()
        {
            this.clinica = new Clinicas();
            this.endereco = new Enderecos();
        }

        public ClinicasCreateViewModel(Clinicas pclinica, Enderecos pendereco)
        {
            this.clinica = pclinica;
            this.endereco = pendereco;
        }
    }
}