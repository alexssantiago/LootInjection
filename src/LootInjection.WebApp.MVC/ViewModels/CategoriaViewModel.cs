﻿using System;
using System.ComponentModel.DataAnnotations;

namespace LootInjection.WebApp.MVC.ViewModels
{
    public class CategoriaViewModel
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }
    }
}