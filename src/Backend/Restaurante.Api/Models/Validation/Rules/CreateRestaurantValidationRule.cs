using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;

namespace Restaurante.Api.Models.Validation.Rules
{
    public class CreateRestaurantValidationRule : AbstractValidator<Restaurant>
    {
        public CreateRestaurantValidationRule()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            // Rules
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("'{PropertyName}' can't be null nor empty.");
        }
    }
}