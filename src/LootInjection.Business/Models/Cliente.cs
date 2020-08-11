using System;
using System.Collections.Generic;

namespace LootInjection.Business.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public int Telefone { get; private set; }
        public OpcaoSexual OpcaoSexual { get; private set; }
        public Nacionalidade Nacionalidade { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public Endereco Endereco { get; private set; }

        public IEnumerable<Conta> Contas { get; set; }

        public Cliente(string nome, DateTime dataNascimento, int telefone, OpcaoSexual opcaoSexual, Nacionalidade nacionalidade, string email, string cpf, Endereco endereco)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            OpcaoSexual = opcaoSexual;
            Nacionalidade = nacionalidade;
            Email = email;
            Cpf = cpf;
            Endereco = endereco;
        }
    }
}