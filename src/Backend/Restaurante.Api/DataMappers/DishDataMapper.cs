using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurante.Api.Models;
using Restaurante.Persistence.Models;

namespace Restaurante.Api.DataMappers
{
    public static class DishDataMapper
    {
        public static Dish MapToDto(this DishEntity self)
        {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }

            var destination = new Dish() {
                Id = self.Id,
                RestaurantId = self.RestaurantId,
                RestaurantName = self.Restaurant.Name,
                Name = self.Name,
                Price = self.Price
            };

            return destination;
        }

        public static List<Dish> MapToDto(this ICollection<DishEntity> self)
        {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }

            var destination = new List<Dish>();

            if (self.Count < 1) {
                return destination;
            }

            foreach (var item in self) {
                destination.Add(item.MapToDto());
            }

            return destination;
        }

        public static DishEntity MapToEntity(this Dish self)
        {
            if (self == null) {
                throw new ArgumentNullException(nameof(self));
            }

            var destination = new DishEntity() {
                RestaurantId = self.RestaurantId,
                Name = self.Name,
                Price = self.Price
            };

            return destination;
        }
    }
}