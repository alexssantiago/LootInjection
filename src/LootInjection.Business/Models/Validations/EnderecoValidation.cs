using FluentValidation;

namespace LootInjection.Business.Models.Validations
{
    public class EnderecoValidation : AbstractValidator<Endereco>
    {
        public EnderecoValidation()
        {
            RuleFor(e => e.ClienteId)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.");

            RuleFor(e => e.Cep)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.");
        }
    }
}