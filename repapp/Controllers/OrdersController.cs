using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///using AutoMapper;
using repapp.Data;
using repapp.Data.Entities;
using repapp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace repapp.Controllers
{
    [Route("api/[Controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<OrdersController> _logger;
        private readonly IMapper _mapper;

        // private readonly IMapper _mapper;





        public OrdersController(IProductRepository repository,
          ILogger<OrdersController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            
        }

        [HttpGet]
        public IActionResult Get( bool includeItems=true)
        {
            try
            {
                var results=_repository.GetAllOrders(includeItems);

                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to return orders: {ex}");
                return BadRequest($"Failed to return orders");
            }
        }






        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var order = (_repository.GetOrderById(id));

                // rrturn ok if order does not equal null
                if (order != null) return Ok(order);
                // return not found if the order is null because Id may not be valid
                else return NotFound();



            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to return orders: {ex}");
                return BadRequest($"Failed to return orders");
            }
        }
        /*
        [HttpPost]
        public IActionResult Post( [FromBody] Order model)
        {
            return Ok();

        or  throw new NotImplementedException();
        }
        */



        [HttpPost]
        public IActionResult Post([FromBody] OrderViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newOrder = _mapper.Map<Order>(model);

                    if (newOrder.OrderDate == DateTime.MinValue)
                    {
                        newOrder.OrderDate = DateTime.Now;
                    };

                    _repository.AddEntity(newOrder);
                    if (_repository.SaveAll())
                    {
                        return Created($"/api/orders/{newOrder.Id}", _mapper.Map<OrderViewModel>(newOrder));
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to save new order: {ex}");
            }

            return BadRequest("Failed to save new order.");
        }
    }
}
