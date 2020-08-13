using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace LootInjection.WebApp.MVC.ViewModels
{
    public class EnderecoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [HiddenInput]
        public Guid ClienteId { get; set; }

        public string Logradouro { get; set; }

        [DisplayName("Número")]
        public string Numero { get; set; }
        
        public string Complemento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cep { get; set; }
        
        public string Bairro { get; set; }
        
        public string Cidade { get; set; }
        
        public string Estado { get; set; }

        public ClienteViewModel Cliente { get; set; }
    }
}