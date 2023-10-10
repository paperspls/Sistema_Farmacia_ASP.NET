using FluentValidation;
using SistemaFarmacia.Model;

namespace SistemaFarmacia.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {

            RuleFor(c => c.tipo)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100);

        }
    }
}