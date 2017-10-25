using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Persistence.Models
{
    public class DishEntity : BaseEntity
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public virtual RestaurantEntity Restaurant { get; set; }
    }
}
