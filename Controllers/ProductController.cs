using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductWebAPI.Interfaces;
using ProductWebAPI.Models;

namespace ProductWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {

        private readonly IProductRepo _productRepo;

        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {

            IEnumerable<Product> products = null;

            products = _productRepo.GetAllProducts();

            return Ok(products);

        }

        // GET: api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {

                Product product = null;

                product = _productRepo.GetProduct(id);

                if (product != null)
                {
                    return Ok(product);
                }
                else
                {
                    return NotFound("Product with Id = " + id.ToString() + " not found to display.");

                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            try
            {
                product = _productRepo.InsertProduct(product);

                if (product != null)
                {

                    string strRequestUri = Request.Host + "/" + Request.PathBase;
                    var message = Created(strRequestUri + "/" + product.productID.ToString(), product);
                    return message;

                }
                else
                {

                    return BadRequest("Product with Id = " + product.productID.ToString() + " not Inserted.");

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<controller>/5
        // UPDATE
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            try
            {

                product = _productRepo.UpdateProduct(product);

                if (product != null)
                {

                    string strRequestUri = Request.Host + "/" + Request.PathBase;
                    var message = Created(strRequestUri + "/" + product.productID.ToString(), product);
                    return message;

                }
                else
                {

                    return BadRequest("Product with Id = " + id.ToString() + " not found to Update.");

                }

            }

            catch (Exception ex)
            {

                return BadRequest(ex);

            }

        }


        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            Product product = null;

            product = _productRepo.DeleteProduct(id);

            if (product != null)
            {
                return Ok(product);
            }
            else
            {

                return NotFound("Product with Id = " + id.ToString() + " not found to Delete.");

            }

        }

    }
}