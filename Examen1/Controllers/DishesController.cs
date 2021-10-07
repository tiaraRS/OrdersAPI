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
    [Route("api/dishes")]
    public class DishesController:Controller
    {
        private IDishService _dishService;
        public DishesController(IDishService itemService)
        {
            _dishService = itemService;
        }

        [HttpPost]
        public ActionResult<DishModel> CreateDish([FromBody] DishModel dish)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var newDish = _dishService.CreateDish(dish);
                return Created($"/api/sales/{newDish.Id}", newDish);
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

        [HttpGet]
        public ActionResult<IEnumerable<DishModel>> GetDishes()
        {
            return Ok(_dishService.GetDishes());
        }
       
    }
}
