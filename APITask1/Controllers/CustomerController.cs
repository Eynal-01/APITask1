using APITask1.Dtos;
using APITask1.Entities;
using APITask1.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace APITask1.Controllers
{
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<CustomerDto> GetCustomers()
        {
            var items = _customerService.GetAll();
            var dataToReturn = items.Select(c =>
            {
                return new CustomerDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Email = c.Email,
                };
            });
            return dataToReturn;
        }

        // GET api/<CustomerController>/5
        //[HttpGet("{id}")]
        //public CustomerDto? GetCustomer(int id)
        //{
        //    var customer = _customerService.Get(id);
        //    if (customer != null)
        //    {
        //        var data = new CustomerDto
        //        {
        //            Id = customer.Id,
        //            Name = customer.Name,
        //            Email = customer.Email
        //        };
        //        return data;
        //    }
        //    return null;
        //}

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] CustomerDto dto)
        {
            try
            {
                var customer = new Customer
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Email = dto.Email
                };
                _customerService.Add(customer);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerDto dto)
        {
            try
            {
                var item = _customerService.Get(id);
                if (item == null)
                {
                    return NotFound();
                }
                item.Name = dto.Name;
                item.Email = dto.Email;
                item.Id = dto.Id;
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _customerService.Get(id);
                if (item == null)
                {
                    return NotFound();
                }
                _customerService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
