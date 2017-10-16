using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;

namespace Restaurante.Api.Models.Validation.Rules
{
    public class UpdateDishValidationRule : AbstractValidator<Dish>
    {
        public UpdateDishValidationRule()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            // Rules
            RuleFor(p => p.Id)
                .GreaterThan(0).WithMessage("'{PropertyName}' has an invalid value.");

            RuleFor(p => p.RestaurantId)
                .GreaterThan(0).WithMessage("'{PropertyName}' can't be null nor empty.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("'{PropertyName}' can't be null nor empty.");

            RuleFor(p => p.Price)
                .GreaterThanOrEqualTo(0).WithMessage("'{PropertyName}' has an invalid value.");
        }
    }
}