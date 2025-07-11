using TravelUpApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ProductApi.Controllers
{
    public class ProductsController : ApiController
    {
        static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Apple", Category = "Fruit", Amount = 100, Status = true },
            new Product { Id = 2, Name = "Shirt", Category = "Clothing", Amount = 50, Status = true }
        };


        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _products;
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public IHttpActionResult Post(Product product)
        {
            if (product == null || string.IsNullOrEmpty(product.Name))
                return BadRequest("Invalid product data.");

            product.Id = _products.Count + 1;
            _products.Add(product);
            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, Product updated)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            product.Name = updated.Name;
            product.Status = updated.Status;
            product.Category = updated.Category;
            product.Amount = updated.Amount;

            return Ok(product);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            _products.Remove(product);
            return Ok();
        }
    }
}
