using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SafeShopAPI.Domain.Entities;
using SafeShopAPI.Domain.Interfaces;
using SafeShopAPI.Domain.Models;

namespace SafeShopAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger, IProductRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _repository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product is null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Guid id = Guid.NewGuid();

            var product = new Product(
                id,
                viewModel.Name,
                viewModel.Description,
                viewModel.Price,
                viewModel.PromoPrice
            );

            await _repository.Add(product);
            return Created($"/products/{product.Id}", product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productUpdated = await _repository.GetByIdAsync(id);

            if (productUpdated is null)
                return NotFound();

            productUpdated.Update(
                name: viewModel.Name,
                description: viewModel.Description,
                price: viewModel.Price,
                promoPrice: viewModel.PromoPrice
            );

            await _repository.Update(productUpdated);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var productDeleted = await _repository.GetByIdAsync(id);

            if (productDeleted is null)
                return NotFound();

            await _repository.DeleteByIdAsync(productDeleted.Id);

            return NoContent();
        }
    }
}
