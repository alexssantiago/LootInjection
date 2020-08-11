using System;

namespace LootInjection.Business.Models
{
    public class Endereco : Entity
    {
        public Guid ClienteId { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Cep { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        /* EF Relation */
        public Cliente Cliente { get; private set; }

        public Endereco(Guid clienteId, string logradouro, string numero, string complemento, string cep, string bairro, string cidade, string estado)
        {
            ClienteId = clienteId;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Cep = cep;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }
    }
}