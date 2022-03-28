using System.Net;
using Catalog.API.Entities;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
// [Authorize("ClientIdPolicy")]
public class CatalogController : ControllerBase
{
    private readonly ILogger<CatalogController> _logger;
    private readonly IProductRepository _repository;

    public CatalogController(IProductRepository productRepository, ILogger<CatalogController> logger)
    {
        _repository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Product>), (int) HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products = await _repository.GetProducts();
        return Ok(products);
    }

    [HttpGet]
    [Route("{id:length(24)}", Name = "GetProduct")]
    [ProducesResponseType((int) HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(Product), (int) HttpStatusCode.OK)]
    public async Task<ActionResult<Product>> GetProductById(string id)
    {
        var product = await _repository.GetProductById(id);

        if (product == null)
        {
            _logger.LogError($"Product with id: {id} not found");
            return NotFound();
        }

        return Ok(product);
    }

    [HttpGet]
    [Route("[action]/{name:minlength(1)}")]
    [ProducesResponseType(typeof(IEnumerable<Product>), (int) HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductByName(string name)
    {
        var products = await _repository.GetProductByName(name);
        return Ok(products);
    }

    [HttpGet]
    [Route("[action]/{category:minlength(1)}")]
    [ProducesResponseType(typeof(IEnumerable<Product>), (int) HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(string category)
    {
        var products = await _repository.GetProductByCategory(category);
        return Ok(products);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Product), (int) HttpStatusCode.OK)]
    public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
    {
        await _repository.CreateProduct(product);
        return CreatedAtAction(nameof(GetProductById), new {id = product.Id}, product);
    }

    [HttpPut]
    [ProducesResponseType(typeof(void), (int) HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateProduct([FromBody] Product product)
    {
        await _repository.UpdateProduct(product);
        return Ok();
    }

    [HttpDelete]
    [Route("{id:length(24)}", Name = "DeleteProduct")]
    [ProducesResponseType(typeof(void), (int) HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteProductById(string id)
    {
        await _repository.DeleteProduct(id);
        return Ok();
    }
}