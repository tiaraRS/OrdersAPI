using Orders.Data.Repository;
using Orders.Exceptions;
using Orders.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
       
        private DishModel GetDish(int dishId)
        {
            var dish = _orderRepository.GetDish(dishId);
            if (dish == null) throw new NotFoundException($"Dish with id {dishId} does not exist");
            return dish;
        }


        public DeliverOrderModel CreateOrder(DeliverOrderModel order)
        {
            var dish = GetDish(order.DishId);
            order.DeliverName = null;
            order.IsDelivered = null;
            return _orderRepository.CreateOrder(order);
        }

        private DeliverOrderModel GetOrder(int orderId)
        {
            var order = _orderRepository.GetOrder(orderId);
            if (order == null) throw new NotFoundException($"order with id {orderId} does not exist");
            return order;
        }
       
        public DeliverOrderModel CompleteOrder(int orderId, DeliverOrderModel orderInfoForCompletion)
        {
            var order = GetOrder(orderId);
            if (order.IsDelivered != null && order.DeliverName != null) throw new AlreadyCompletedOrderException($"Order with id {orderId} is already complete");
            order.IsDelivered = true;
            order.DeliverName = orderInfoForCompletion.DeliverName ?? "Juancho";           
            _orderRepository.UpdateOrder(orderId, order);
            return order;
        }

        public IEnumerable<DeliverOrderModel> GetNonCompletedOrders()
        {
            var orders = _orderRepository.GetOrders();
            var nonCompletedOrders = orders.Where(order => order.DeliverName == null && order.IsDelivered == null);
            return nonCompletedOrders;
        }

        public Dictionary<string, int> GetReportSalesByRestaurant() //como diccionario
        {           
            var saleReportByRestaurant = new Dictionary<string, int>();
            var orders = _orderRepository.GetOrders();
            var completedOrders = orders.Where(order => order.DeliverName != null && order.IsDelivered == true);
            saleReportByRestaurant = completedOrders.GroupBy(order => GetDish(order.DishId).RestaurantName).ToDictionary(d => d.Key, d => d.Count());
            return saleReportByRestaurant;
         }

        public IEnumerable<ReportSalesByRestaurant> GetReportSalesByRestaurant2() //como reporte
        {
            var saleReportByRestaurant = new List<ReportSalesByRestaurant>();
            var orders = _orderRepository.GetOrders();
            var completedOrders = orders.Where(order => order.DeliverName != null && order.IsDelivered == true);
            var saleGroupByRestaurantName = completedOrders.GroupBy(order => GetDish(order.DishId).RestaurantName);

            saleReportByRestaurant = saleGroupByRestaurantName.Select(s => new ReportSalesByRestaurant() { Name = s.Key, CompletedOrders = s.Count() }).ToList();
            return saleReportByRestaurant;
        }
        public IEnumerable<DeliverOrderModel> GetOrders()
        {
            return _orderRepository.GetOrders();
        }
    }
}
