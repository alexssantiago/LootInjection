using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LootInjection.Business.Models.Enums;

namespace LootInjection.WebApp.MVC.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter no máximo {1} caracteres")]
        public string Nome { get; set; }

        [DisplayName("Data de Nascimento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataNascimento { get; set; }

        public int Telefone { get; set; }

        [DisplayName("Opção Sexual")]
        public OpcaoSexual OpcaoSexual { get; set; }
        
        public Nacionalidade Nacionalidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cpf { get; set; }
        
        public EnderecoViewModel Endereco { get; set; }

        public IEnumerable<ContaViewModel> Contas { get; set; }
    }
}