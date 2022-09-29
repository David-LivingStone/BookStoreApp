using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _Repository;

        public OrderController(IOrderRepository orderRepository)
        {
            _Repository = orderRepository;
        }
        // GET: api/<OrderController>
        [HttpGet ("")]
        public async Task<IActionResult> GetAllOrders(OrderModel orderModel)
        {
            var result =  await _Repository.GetAllOrders(orderModel);
            return Ok(result);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost("")]
        public async Task<IActionResult> MakeOrder([FromBody] OrderModel orderModel)
        {
            var result = await _Repository.MakeOrder(orderModel);
            return Ok(result);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
