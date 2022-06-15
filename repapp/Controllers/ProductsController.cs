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
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
       // private readonly IProductsRepository _repository;
        private readonly ILogger<ProductsController> _logger;
        private readonly DataDbContext _context;
        private readonly IProductsRepository _productsRepository;

        public ProductsController(IProductsRepository res, DataDbContext context, ILogger<ProductsController> logger)
        {
              _context = context;
            _logger = logger;
            _productsRepository = res;
        }

        [HttpGet]
     [ProducesResponseType(200)]
     [ProducesResponseType(400)]
    public async Task<ActionResult<IEnumerable<Product>>> Get()
    {
            try
            {
                return await _context.Products.ToListAsync();
            }

            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products: {ex}");
                return BadRequest("failed to get products");
            }
    }
  


    [HttpGet("{Id}")]
    
    public async Task<ActionResult<Product>> Getuser(int Id)
    {
        try
        {
            return await  _context.Products.FindAsync(Id);
        }

        catch (Exception ex)
        {
            _logger.LogError($"Failed to get products: {ex}");
            return BadRequest("failed to get products");
        }
    }
}


}



    
