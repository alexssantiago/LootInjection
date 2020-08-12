using System;
using System.Collections.Generic;
using LootInjection.Business.Models.Enums;

namespace LootInjection.Business.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Telefone { get; set; }
        public OpcaoSexual OpcaoSexual { get; set; }
        public Nacionalidade Nacionalidade { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public Endereco Endereco { get; set; }

        public IEnumerable<Conta> Contas { get; set; }
    }
}