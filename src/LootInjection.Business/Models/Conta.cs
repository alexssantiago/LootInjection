using System;
using LootInjection.Business.Models.Enums;

namespace LootInjection.Business.Models
{
    public class Conta : Entity
    {
        public Guid ClienteId { get; set; }
        public TipoConta Tipo { get; set; }
        public string Descricao { get; set; }
        public decimal Saldo { get; set; }

        // EF Relation
        public Cliente Cliente { get; set; }
    }
}