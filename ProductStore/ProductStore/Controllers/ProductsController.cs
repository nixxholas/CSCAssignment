﻿using ProductStore.Models;
using ProductStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProductStore.Controllers
{
    public class ProductsController : ApiController
    {
        static readonly TalentRepository repository = new TalentRepository();

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/talents")]
        public IEnumerable<Talent> GetAllTalents()
        {
            return repository.GetAll();
        }

        [Route("api/talents/{id:int}")]
        public Talent GetTalent(int id)
        {
            Talent item = repository.Get(id);
            if (item == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }
    }
}