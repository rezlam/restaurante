using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation.Results;
using Restaurante.Api.Models.Validation.Rules;

namespace Restaurante.Api.Models.Validation
{
    public static class DishValidator
    {
        public static bool TryValidateForCreate(this Dish self, out string message)
        {
            message = null;

            if (self == null) {
                message = "Could not parse object: invalid object representation.";
                return false;
            }

            var validator = new CreateDishValidationRule();
            var validationResult = validator.Validate(self);

            if (validationResult.IsValid == false) {
                message = validationResult.Errors.FirstOrDefault().ErrorMessage;
            }

            return validationResult.IsValid;
        }

        public static bool TryValidateForUpdate(this Dish self, out string message)
        {
            message = null;

            if (self == null) {
                message = "Could not parse object: invalid object representation.";
                return false;
            }

            var validator = new UpdateDishValidationRule();
            var validationResult = validator.Validate(self);

            if (validationResult.IsValid == false) {
                message = validationResult.Errors.FirstOrDefault().ErrorMessage;
            }

            return validationResult.IsValid;
        }
    }
}