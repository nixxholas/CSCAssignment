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
    public class ProductsV3Controller : ApiController
    {
        static readonly IProductRepository repository = new ProductRepository();

        [Route("api/v3/products/version")]
        //code for version 1
        [HttpGet]
        public string[] GetVersion()
        {
            return new string[] { "hello", "version 3", "3" };
        }

        //Version 3
        //[Authorize]
        [HttpGet]
        [Route("api/v3/products")]
        public IEnumerable<Product> GetAllProductsFromRepository()
        {
            return repository.GetAll();
        }

        //Route constraints let you restrict how the parameters in the route template are matched.
        //The general syntax is "{parameter:constraint}".  
        //Constraints on URL parameters
        //We can even restrict the template placeholder to the type of parameter it can have.
        //For example, we can restrict that the request will be only served if the id is greater than 2.
        //Otherwise the request will not work. For this, we will apply multiple constraints in the same request:
        //Type of the parameter id must be an integer.
        //id should be greater than 2.  
        //http://localhost:9000/api/v3/products/1 404 error code
        //[HttpGet]
        //[Route("api/v3/products/{id:int:min(2)}", Name = "getProductByIdv3")]
        //public Product retrieveProductfromRepository(int id)
        //{
        //    Product item = repository.Get(id); if (item == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //    return item;
        //}

        [HttpGet]
        [Route("api/v3/products", Name = "getProductByCategoryv3")]
        //http://localhost:9000/api/v3/products?category=  
        //http://localhost:9000/api/v3/products?category=Groceries
        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return repository.GetAll().Where(p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
        }

        //Response code: By default, the Web API framework sets the response status code to 200 (OK).
        //But according to the HTTP/1.1 protocol, when a POST request results in the creation of a resource, the server should reply with status 201 (Created).
        //Location: When the server creates a resource, it should include the URI of the new resource in the Location header of the response.
        [HttpPost]
        [ValidateModel]
        [Route("api/v3/products")]
        public HttpResponseMessage PostProduct(Product item)
        {
            if (ModelState.IsValid)
            {
                item = repository.Add(item);
                var response = Request.CreateResponse<Product>(HttpStatusCode.Created, item);

                string uri = Url.Link("getProductByIdv3", new { id = item.Id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
        
        [HttpGet]
        [Route("api/v3/products")]
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
        [Route("api/v3/products/{id:int}", Name = "getProductByIdv3")]
        public IHttpActionResult GetProduct(int id)
        {
            var product = repository.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut]
        [Route("api/v3/products/{id:int}")]
        public void PutProduct(int id, Product product)
        {
            product.Id = id;
            if (!repository.Update(product))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        [HttpDelete]
        [Route("api/v3/products/{id:int}")]
        public void DeleteProduct(int id)
        {
            repository.Remove(id);
        }
    }
}