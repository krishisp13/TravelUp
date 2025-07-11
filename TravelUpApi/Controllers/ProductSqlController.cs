using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TravelUpApi.Entity;
using TravelUpApi.Models;

namespace TravelUpApi.Controllers
{
    [RoutePrefix("api/productsql")]
    public class ProductSqlController : ApiController
    {
        private readonly AppDBContext _context = new AppDBContext();

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        [Route("save")]
        public IHttpActionResult Post(Product product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Put(int id, Product product)
        {
            var existing = _context.Products.Find(id);
            if (existing == null) return NotFound();

            existing.Name = product.Name;
            existing.Category = product.Category;
            existing.Amount = product.Amount;
            existing.Status = product.Status;

            _context.SaveChanges();
            return Ok(existing);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok();
        }
    }
}
