using Orders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Data.Repository
{
    public interface IOrderRepository
    {
        //Dish
        public DishModel CreateDish(DishModel dish);
        public DishModel GetDish(int dishId);
        public IEnumerable<DishModel> GetDishes();

        //Order
        public DeliverOrderModel CreateOrder(DeliverOrderModel order);
        public IEnumerable<DeliverOrderModel> GetOrders();

        public DeliverOrderModel GetOrder(int orderId);

        public DeliverOrderModel UpdateOrder(int orderId, DeliverOrderModel order);
       


    }
}
