using System;

namespace LootInjection.Business.Models
{
    public class Conta
    {
        public Guid ClienteId { get; private set; }
        public TipoConta Tipo { get; private set; }
        public string Descricao { get; private set; }
        public decimal Saldo { get; private set; }

        // EF Relation
        public Cliente Cliente { get; private set; }

        public Conta(Guid clienteId, TipoConta tipo, string descricao, decimal saldo)
        {
            ClienteId = clienteId;
            Tipo = tipo;
            Descricao = descricao;
            Saldo = saldo;
        }
    }
}