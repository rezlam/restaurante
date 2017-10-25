using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurante.Api.Models;
using Restaurante.Persistence.Models;

namespace Restaurante.Api.DataMappers
{
    public static class RestaurantDataMapper
    {
        public static Restaurant MapToDto(this RestaurantEntity self)
        {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }

            var destination = new Restaurant() {
                Id = self.Id,
                Name = self.Name
            };

            if (self.Dishes != null) {
                destination.Dishes = self.Dishes.MapToDto();
            }

            return destination;
        }

        public static List<Restaurant> MapToDto(this List<RestaurantEntity> self)
        {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }

            var destination = new List<Restaurant>();

            if (self.Count < 1) {
                return destination;
            }

            foreach (var item in self) {
                destination.Add(item.MapToDto());
            }

            return destination;
        }

        public static RestaurantEntity MapToEntity(this Restaurant self)
        {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }

            var destination = new RestaurantEntity() {
                Name = self.Name
            };

            return destination;
        }
    }
}