using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation.Results;
using Restaurante.Api.Models.Validation.Rules;

namespace Restaurante.Api.Models.Validation
{
    public static class RestaurantValidator
    {
        public static bool TryValidateForCreate(this Restaurant self, out string message)
        {
            message = null;

            if (self == null) {
                message = "Could not parse object: invalid object representation.";
                return false;
            }

            var validator = new CreateRestaurantValidationRule();
            var validationResult = validator.Validate(self);

            if (validationResult.IsValid == false) {
                message = validationResult.Errors.FirstOrDefault().ErrorMessage;
            }

            return validationResult.IsValid;
        }

        public static bool TryValidateForUpdate(this Restaurant self, out string message)
        {
            message = null;

            if (self == null) {
                message = "Could not parse object: invalid object representation.";
                return false;
            }

            var validator = new UpdateRestaurantValidationRule();
            var validationResult = validator.Validate(self);

            if (validationResult.IsValid == false) {
                message = validationResult.Errors.FirstOrDefault().ErrorMessage;
            }

            return validationResult.IsValid;
        }
    }
}