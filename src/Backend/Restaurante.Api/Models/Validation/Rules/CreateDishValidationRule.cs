using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;

namespace Restaurante.Api.Models.Validation.Rules
{
    public class CreateDishValidationRule : AbstractValidator<Dish>
    {
        public CreateDishValidationRule()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            // Rules
            RuleFor(p => p.RestaurantId)
                .GreaterThan(0).WithMessage("'{PropertyName}' can't be null nor empty.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("'{PropertyName}' can't be null nor empty.");

            RuleFor(p => p.Price)
                .GreaterThanOrEqualTo(0).WithMessage("'{PropertyName}' has an invalid value.");
        }
    }
}