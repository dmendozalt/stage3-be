using AutoMapper;
using Inventory.Contracts.Repository;
using Inventory.Core.V1;
using Inventory.Entities.DTOs;
using Inventory.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventory.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductCore _productCore;

        public ProductsController(ILogger<Product> logger, IMapper mapper, IProductRepository context)
        {
            _productCore = new ProductCore(logger, mapper, context);
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var response = await _productCore.GetProductsAsync();
            return StatusCode((int)response.StatusHttp, response);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var response = await _productCore.GetProductByIdAsync(id);
            return StatusCode((int)response.StatusHttp, response);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] ProductCreateDto product)
        {
            var response = await _productCore.AddProductAsync(product);
            return StatusCode((int)response.StatusHttp, response);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Put(int id, [FromBody] ProductUpdateDto product)
        {
            var response = await _productCore.UpdateProductAsync(id,product);
            return StatusCode((int)response.StatusHttp, response);
        }

        // GET: api/<ProductsController>
        [HttpGet("stock")]
        public async Task<ActionResult<IEnumerable<ProductStockDto>>> GetStock()
        {
            var response = await _productCore.GetStockAsync();
            return StatusCode((int)response.StatusHttp, response);
        }


        // GET api/<ProductsController>/5
        [HttpGet("stock/{id}")]
        public async Task<ActionResult<ProductStockDto>> GetStock(int id)
        {
            var response = await _productCore.GetStockByIdAsync(id);
            return StatusCode((int)response.StatusHttp, response);
        }

    }
}
