using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Models
{
    public class ReportSalesByRestaurant
    {
        public string Name { get; set; }
        public int CompletedOrders { get; set; }
    }
}
