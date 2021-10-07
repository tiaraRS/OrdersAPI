using Orders.Exceptions;
using Orders.Models;
using Orders.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Controllers
{
    [Route("api/orders")]
    public class OrdersController:Controller
    {
        private IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DeliverOrderModel>> GetOrders()
        {
            return Ok(_orderService.GetOrders());
        }

        [HttpGet("NonCompleteOrders")]
        public ActionResult<IEnumerable<DeliverOrderModel>> GetNonCompletedDeliveryOrders()
        {
            return Ok(_orderService.GetNonCompletedOrders());
        }

        [HttpPost]
        public ActionResult<DeliverOrderModel> CreateOrder([FromBody]DeliverOrderModel order)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var newOrder = _orderService.CreateOrder(order);
                return Created($"/api/orders/{newOrder.Id}", newOrder);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something happened");
            }
            
        }

        [HttpPut("{orderId:int}/completeOrder")]
        public ActionResult<DeliverOrderModel> CompleteOrder(int orderId, [FromBody] DeliverOrderModel orderValuesForCompletion)
        {
            try
            {
                var order = _orderService.CompleteOrder(orderId, orderValuesForCompletion); 
                return order;
            }
            catch(AlreadyCompletedOrderException e)
            {
                return BadRequest(e.Message);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
           
        }

        /*[HttpGet("sellsByRestaurant")]
        public ActionResult<Dictionary<string, int>> GetReportSalesByRestaurant()
        {
            try
            {
                var sellsByRestaurant = _orderService.GetReportSalesByRestaurant();
                return sellsByRestaurant;
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }            
        }*/

        [HttpGet("sellsByRestaurant")]
        public ActionResult<IEnumerable<ReportSalesByRestaurant>> GetReportSalesByRestaurant()
        {
            try
            {
                var sellsByRestaurant = _orderService.GetReportSalesByRestaurant2();
                return Ok(sellsByRestaurant);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }



    }
}
