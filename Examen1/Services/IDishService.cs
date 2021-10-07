using Orders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Services
{
    public interface IDishService
    {
        public DishModel CreateDish(DishModel dish);
        public IEnumerable<DishModel> GetDishes();

    }
}
