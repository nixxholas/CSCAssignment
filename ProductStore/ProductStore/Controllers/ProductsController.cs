using ProductStore.Models;
using ProductStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProductStore.Controllers
{
    public class ProductsController : ApiController
    {
        static readonly TalentRepository repository = new TalentRepository();

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/talents")]
        public IEnumerable<Talent> GetAllTalents()
        {
            return repository.GetAll();
        }

        [HttpGet]
        [Route("api/talents/{id:int}", Name = "getTalentById")]
        public Talent GetTalent(int id)
        {
            Talent item = repository.Get(id);
            if (item == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        [HttpPost]
        [Route("api/talents")]
        public HttpResponseMessage PostTalent(Talent talent)
        {
            if (ModelState.IsValid)
            {
                talent = repository.Add(talent);
                var response = Request.CreateResponse(HttpStatusCode.Created, talent);

                string uri = Url.Link("getTalentById", new { id = talent.Id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpPut]
        [Route("api/talents/{id:int}")]
        public void PutTalent(int id, Talent talent)
        {
            talent.Id = id;
            if (!repository.Update(talent))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        [HttpDelete]
        [Route("api/talents/{id:int}")]
        public void DeleteTalent(int id)
        {
            repository.Remove(id);
        }
    }
}
