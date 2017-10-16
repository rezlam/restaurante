using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;

namespace Restaurante.Api.Models.Validation.Rules
{
    public class UpdateRestaurantValidationRule : AbstractValidator<Restaurant>
    {
        public UpdateRestaurantValidationRule()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            // Rules
            RuleFor(p => p.Id)
                .GreaterThan(0).WithMessage("'{PropertyName}' has an invalid value.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("'{PropertyName}' can't be null nor empty.");
        }
    }
}