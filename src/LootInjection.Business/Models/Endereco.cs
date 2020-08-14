using System;

namespace LootInjection.Business.Models
{
    public class Endereco : Entity
    {
        public Guid ClienteId { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        /* EF Relation */
        public Cliente Cliente { get; set; }
    }
}