using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurante.Api.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Dish> Dishes { get; set; } = new List<Dish>();
    }
}