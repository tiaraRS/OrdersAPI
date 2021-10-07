using Orders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private IList<DeliverOrderModel> _orders;
        private IList<DishModel> _dishes;
        public OrderRepository()
        {
            _orders = new List<DeliverOrderModel>();
            _dishes = new List<DishModel>();
            _dishes.Add(new DishModel()
            {
                Id = 1,
                Name = "Panchicono",
                Category ="Pollo",
                Price = 21f,
                RestaurantName = "Panchita"
                
            });
            _dishes.Add(new DishModel()
            {
                Id = 2,
                Name = "Pizza Margarita",
                Category = "Pastas",
                Price = 65f,
                RestaurantName = "Overtime"

            });
            _orders.Add(new DeliverOrderModel() { 
                Id=1,
                ClientName = "Pedro",
                DishId = 1,
                Address = "Av America 2394"              
            });
            _orders.Add(new DeliverOrderModel()
            {
                Id = 2,
                ClientName = "Dani",
                DishId = 2,
                Address = "Av Sucre 3820"
            });

        }
        public DishModel CreateDish(DishModel dish)
        {
            var lastDish = _dishes.OrderByDescending(d => d.Id).FirstOrDefault();
            var nextId = lastDish != null ? lastDish.Id + 1 : 1;
            dish.Id = nextId;
            _dishes.Add(dish);
            return dish;
        }

        public DishModel GetDish(int dishId)
        {
            return _dishes.FirstOrDefault(d => d.Id == dishId);
        }

        public DeliverOrderModel CreateOrder(DeliverOrderModel order)
        {
            var lastOrder = _orders.OrderByDescending(o => o.Id).FirstOrDefault();
            var nextId = lastOrder != null ? lastOrder.Id + 1 : 1;
            order.Id = nextId;
            _orders.Add(order);
            return order;
        }

        public IEnumerable<DeliverOrderModel> GetOrders()
        {
            return _orders;
        }

        public DeliverOrderModel GetOrder(int orderId)
        {
            return _orders.FirstOrDefault(o => o.Id == orderId);
        }

        public DeliverOrderModel UpdateOrder(int orderId, DeliverOrderModel order)
        {
            var orderToUpdate = GetOrder(orderId);
            orderToUpdate.ClientName = order.ClientName ?? order.ClientName;
            orderToUpdate.Address = order.Address ?? order.Address;
            orderToUpdate.IsDelivered = order.IsDelivered ?? order.IsDelivered;
            orderToUpdate.DeliverName = order.DeliverName ?? order.DeliverName;
            //orderToUpdate.DishId = order.DishId ?? order.DishId;
            return orderToUpdate;

        }

        public IEnumerable<DishModel> GetDishes()
        {
            return _dishes;
        }        
    }
}
