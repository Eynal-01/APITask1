using APITask1.Dtos;
using APITask1.Entities;
using APITask1.Services.Abstract;
using APITask1.Services.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace APITask1.Controllers
{
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/<OrderController>
        [HttpGet("GetAllOrders")]
        public IEnumerable<OrderDto> GetOrders()
        {
            var items = _orderService.GetAll();
            var dataToReturn = items.Select(o =>
            {
                return new OrderDto
                {
                    OrderDate = o.OrderDate,
                    OrderName = o.OrderName,
                    Product = o.Product,
                    ProductId = o.ProductId,
                    CustomerId = o.CustomerId,
                    Customer = o.Customer,
                    Id = o.Id,
                };
            });
            return dataToReturn;
        }

        // GET api/<OrderController>/5
        [HttpGet("GetOrder")]
        public OrderDto? GetOrder(int id)
        {
            var order = _orderService.Get(id);
            if (order != null)
            {
                var data = new OrderDto
                {
                    OrderName = order.OrderName,
                    OrderDate = order.OrderDate,
                    Product = order.Product,
                    Customer = order.Customer,
                    ProductId = order.ProductId,
                    CustomerId = order.CustomerId,
                    Id = order.Id
                };
                return data;
            }
            return null;
        }

        // POST api/<OrderController>
        [HttpPost("PostOrder")]
        public IActionResult Post([FromBody] OrderDto dto)
        {
            try
            {
                var order = new Order
                {
                    //Id = dto.Id,
                    OrderDate = dto.OrderDate,
                    OrderName = dto.OrderName,
                    Product = dto.Product,
                    ProductId = dto.ProductId,
                    CustomerId = dto.CustomerId,
                    Customer = dto.Customer,
                };
                _orderService.Add(order);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<OrderController>/5
        [HttpPut("PutOrder")]
        public IActionResult Put(int id, [FromBody] OrderDto dto)
        {
            try
            {
                var item = _orderService.Get(id);
                if (item == null)
                {
                    return NotFound();
                }
                item.Product = dto.Product;
                item.ProductId = dto.ProductId;
                item.OrderName = dto.OrderName;
                item.OrderDate = dto.OrderDate;
                item.CustomerId = dto.CustomerId;
                item.Customer = dto.Customer;
                item.Id = id;
                _orderService.Update(item);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("DeleteOrder")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _orderService.Get(id);
                if (item == null)
                {
                    return NotFound();
                }
                _orderService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
