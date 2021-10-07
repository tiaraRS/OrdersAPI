using Orders.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Services
{
    public interface IOrderService
    {
        public DeliverOrderModel CreateOrder(DeliverOrderModel order);
        public DeliverOrderModel CompleteOrder(int orderId, DeliverOrderModel orderInfoForCompletion);
        public IEnumerable<DeliverOrderModel> GetNonCompletedOrders();
        public IEnumerable<DeliverOrderModel> GetOrders();
        public Dictionary<string, int> GetReportSalesByRestaurant(); //como diccionario
        public IEnumerable<ReportSalesByRestaurant> GetReportSalesByRestaurant2();

    }
}
