using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Models
{
    public class DeliverOrderModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int DishId { get; set; }
        // public int Quantity { get; set; }
        [Required]
        public string ClientName { get; set; }
        [Required]
        public string Address { get; set; }
        public bool? IsDelivered { get; set; }
        public string DeliverName { get; set; }
    }
}
