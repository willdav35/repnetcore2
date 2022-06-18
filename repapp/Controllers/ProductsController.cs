using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using repapp.Data;
using repapp.Data.Entities;

namespace repapp.Controllers
{

    //https://exceptionnotfound.net/asp-net-core-demystified-action-results/

    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        // private readonly IProductsRepository _repository;
        private readonly ILogger<ProductsController> _logger;

        private readonly IProductRepository _res;

        public ProductsController(IProductRepository res, ILogger<ProductsController> logger)
        {

            _logger = logger;
            _res = res;
        }

       
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpGet]
        public  IActionResult  Get()
        {

            try
            {
                return Ok(_res.GetAllProducts());
            }

            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products: {ex}");
                return BadRequest("failed to get products");
            }
        }
            
        

    }
}






    
