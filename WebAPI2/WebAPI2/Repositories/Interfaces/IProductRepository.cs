using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI2.Models;

namespace WebAPI2.Repositories.Interfaces
{
    interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product Get(int id);
        Product Add(Product item);
        void Remove(int id);
        bool Update(Product item);
    }
}