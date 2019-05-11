using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laborator_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Laborator_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductContext context;
        public ProductController(ProductContext context)
        {
            this.context = context;
        }

        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return context.Products;
        }

        // GET api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var exists = context.Products.FirstOrDefault(product => product.Id == id);
            if (exists == null)
            {
                return NotFound();
            }

            return Ok(exists);
        }
        
        // POST api/Products
        [HttpPost]
        public void Post([FromBody] Product p)
        {
            context.Products.Add(p);
            context.SaveChanges();
        }

        // PUT api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            var exists = context.Products.AsNoTracking().FirstOrDefault(f => f.Id ==id);
            if (exists == null)
            {
                context.Products.Add(product);
                context.SaveChanges();
                return Ok(product);
            }
            product.Id = id;
            context.Products.Update(product);
            context.SaveChanges();
            return Ok(product);
        }

        // DELETE api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var exists = context.Products.FirstOrDefault(product => product.Id == id);
            if (exists == null)
            {
                return NotFound();
            }
            context.Products.Remove(exists);
            context.SaveChanges();
            return Ok();
        }
    }
}
