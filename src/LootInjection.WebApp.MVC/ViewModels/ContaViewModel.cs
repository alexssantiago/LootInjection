using LootInjection.Business.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LootInjection.WebApp.MVC.ViewModels
{
    public class ContaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [HiddenInput]
        public Guid ClienteId { get; set; }

        [DisplayName("Tipo de Conta")]
        public TipoConta Tipo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Saldo { get; set; }

        public ClienteViewModel Cliente { get; set; }
    }
}