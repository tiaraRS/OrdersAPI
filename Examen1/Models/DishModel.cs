using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Models
{
    public class DishModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string RestaurantName { get; set; }
        public float? Price { get; set; }
        public string Category { get; set; }

       
    }
}
