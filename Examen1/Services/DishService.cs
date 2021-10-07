using Orders.Data.Repository;
using Orders.Exceptions;
using Orders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Services
{
    public class DishService:IDishService
    {
        private IOrderRepository _orderRepository;
        public DishService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public DishModel CreateDish(DishModel dish)
        {
            return _orderRepository.CreateDish(dish);
        }
        public IEnumerable<DishModel> GetDishes()
        {
            return _orderRepository.GetDishes();
        }
       


    }
}
