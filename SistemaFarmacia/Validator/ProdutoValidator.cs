﻿using FluentValidation;
using SistemaFarmacia.Model;

namespace SistemaFarmacia.Validator
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {

            RuleFor(p => p.Nome)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100);

            RuleFor(p => p.Tarja)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100);

            RuleFor(p => p.Preco)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(100);
        }
    }
}