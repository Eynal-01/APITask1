using APITask1.Dtos;
using APITask1.Entities;
using APITask1.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace APITask1.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<ProductDto> GetProducts()
        {
            var items = _productService.GetAll();
            var dataToReturn = items.Select(p =>
            {
                return new ProductDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Discount = p.Discount
                };
            });
            return dataToReturn;
        }

        // GET api/<ProductController>/5
        //[HttpGet("{id}")]
        //public ProductDto? GetProduct(int id)
        //{
        //    var prod = _productService.Get(id);
        //    if (prod != null)
        //    {
        //        var data = new ProductDto
        //        {
        //            Name = prod.Name,
        //            Price = prod.Price,
        //            Discount = prod.Discount
        //        };
        //        return data;
        //    }
        //    return null;
        //}

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] ProductDto dto)
        {
            try
            {
                var product = new Product
                {
                    Id = dto.Id,
                    Price = dto.Price,
                    Discount = dto.Discount,
                    Name = dto.Name
                };
                _productService.Add(product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductDto dto)
        {
            try
            {
                var item = _productService.Get(id);
                if (item == null)
                {
                    return NotFound();
                }
                item.Price = dto.Price;
                item.Discount = dto.Discount;
                item.Name = dto.Name;
                item.Id = id;
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _productService.Get(id);
                if (item == null)
                {
                    return NotFound();
                }
                _productService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
