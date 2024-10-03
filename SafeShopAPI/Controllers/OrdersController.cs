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
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _repository;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(ILogger<OrdersController> logger, IOrderRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var order = await _repository.GetByIdAsync(id);

            if (order is null)
                return NotFound();

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var order = new Order("1234", viewModel.ProductId, viewModel.Quantity);

            await _repository.Add(order);
            return Created($"/orders/{order.Id}", order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] OrderViewModelUpdate viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var order = await _repository.GetByIdAsync(id);

            if (order is null)
                return NotFound();

            order.Update(viewModel.Quantity);

            await _repository.Update(order);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var order = await _repository.GetByIdAsync(id);

            if (order is null)
                return NotFound();

            await _repository.DeleteByIdAsync(order.Id);

            return NoContent();
        }
    }
}
