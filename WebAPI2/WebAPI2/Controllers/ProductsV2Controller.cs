using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using WebAPI2.Models;
using WebAPI2.Repositories;
using WebAPI2.Repositories.Interfaces;

namespace WebAPI2.Controllers
{
    public class ProductsV2Controller : ApiController
    {
        static readonly IProductRepository repository = new ProductRepository();
        
        [HttpGet]
        [Route("api/v2/products/version")] //http://localhost:9000/api/v1/products/version 
        public string[] GetVersion()
        {
            return new string[] { "hello", "version 2", "2" };
        }

        [HttpGet]
        [Route("api/v2/products/message/")]
        //http://localhost:9000/api/v2/products/message?name1=ji&name2=jii1&name3=ji3
        public HttpResponseMessage GetMultipleNames(String name1, string name2, string name3)
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent("<html><body>Hello World " +
            " name1 =" + name1 +
            " name2= " + name2 +
            " name3=" + name3 +
            " is provided in path parameter</body></html>");

            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }

        [HttpGet]
        [Route("api/v2/products")] //http://localhost:9000/api/v1/products 
        public IEnumerable<Product> GetAllProducts()
        {
            return repository.GetAll();
        }

        [HttpGet]
        [Route("api/v2/products/{id:int}")] //http://localhost:9000/api/v1/products/3 
        public IHttpActionResult GetProduct(int id)
        {
            var product = repository.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        //[HttpGet]
        //[Route("api/v2/products")] //http://localhost:9000/api/v1/products?category=nice
        //public IHttpActionResult GetProduct(string category)
        //{

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(product);
        //}
    }
}
