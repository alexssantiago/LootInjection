using System.ComponentModel.DataAnnotations;

namespace LootInjection.Business.Models.Enums
{
    public enum TipoConta
    {
        Corrente = 1,
        Dinheiro = 2,
        [Display(Name="Poupança")]
        Poupanca = 3,
        Investimentos = 4,
        Outros = 5
    }
}