using ProductStore.Filters;
using ProductStore.Models;
using ProductStore.Repositories;
using ProductStore.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace ProductStore.Controllers
{
    [Route("api/v2/products")]
    public class ProductsV2Controller : ApiController
    {
        static readonly IProductRepository repository = new ProductRepository();
        
        [HttpGet]
        [Route("api/v2/products/version")]
        public string[] GetVersion()
        {
            return new string[] { "hello", "version 2", "2" };
        }

        [HttpGet]
        [Route("api/v2/products")]
        //http://localhost:9000/api/v1/products/message?name1=ji&name2=jii1&name3=ji3
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
        [Route("api/v2/products")]
        public IEnumerable<Product> GetAllProducts()
        {
            return repository.GetAll().ToList();
        }

        [HttpGet]
        [Route("api/v2/products/{id:int}")]
        public IHttpActionResult GetProduct(int id)
        {
            var product = repository.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        //[HttpPost]
        //public Product PostProductDeprecated(Product item)
        //{
        //    item = repository.Add(item);

        //    return item;
        //}

        [HttpPost]
        [Route("api/v2/products")]
        public IHttpActionResult PostProduct(Product item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<Product>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });

            if (uri != null)
            {
                response.Headers.Location = new Uri(uri);
            }

            return Ok();
        }

        [HttpPut]
        [Route("api/v2/products/{id:int}")]
        public void PutProduct(int id, [FromBody]Product product)
        {
            product.Id = id;

            if (!repository.Update(product))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        [HttpDelete]
        [Route("api/v2/products/{id:int}")]
        public void DeleteProduct(int id)
        {
            Product item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repository.Remove(id);
        }
    }
}