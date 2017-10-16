using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurante.Api.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}